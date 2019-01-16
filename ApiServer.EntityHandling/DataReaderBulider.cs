using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Reflection.Emit;
using System.Linq;

namespace ApiServer.EntityHandling
{
     public class DataReaderBulider
    {
        public class IDataReaderEntityBulider<Entity>
        {
            private static readonly MethodInfo getValueMethod = typeof(IDataRecord).GetMethod("get_Item", new Type[] { typeof(int) });
            private static readonly MethodInfo isDBNullMethod = typeof(IDataRecord).GetMethod("IsDBNull", new Type[] { typeof(int) });
            private delegate Entity Load(IDataRecord dataRecord);

            private Load hanlder;
            private IDataReaderEntityBulider() { }

            public Entity Bulid(IDataRecord dataRecord) { return hanlder(dataRecord); }
            public static IDataReaderEntityBulider<Entity>CreateBulider(IDataRecord dataRecord)
            {
                IDataReaderEntityBulider<Entity> dynamicBulider = new IDataReaderEntityBulider<Entity>();
                DynamicMethod method = new DynamicMethod("IDataReaderDynamicCreateEntity", typeof(Entity), new Type[] { typeof(IDataRecord) }, typeof(Entity), true);
                ILGenerator generator = method.GetILGenerator();
                LocalBuilder result = generator.DeclareLocal(typeof(Entity));
                generator.Emit(OpCodes.Newobj, typeof(Entity).GetConstructor(Type.EmptyTypes));
                generator.Emit(OpCodes.Stloc, result);

                var properties = typeof(Entity).GetProperties();    //获取实体属性集合
                for (int i = 0; i < dataRecord.FieldCount; i++)
                {
                    //PropertyInfo propertyInfo = typeof(Entity).GetProperty(properties.FirstOrDefault(x=>x.Name.ToUpper().Equals(dataRecord.GetName(i)))?.Name);
                    PropertyInfo propertyInfo = typeof(Entity).GetProperty(dataRecord.GetName(i));
                    Label endIfLabel = generator.DefineLabel();
                    if(propertyInfo!=null && propertyInfo.GetSetMethod() != null)
                    {
                        generator.Emit(OpCodes.Ldarg_0);
                        generator.Emit(OpCodes.Ldc_I4,i);
                        generator.Emit(OpCodes.Callvirt,isDBNullMethod);
                        generator.Emit(OpCodes.Brtrue, endIfLabel);
                        generator.Emit(OpCodes.Ldloc, result);
                        generator.Emit(OpCodes.Ldarg_0);
                        generator.Emit(OpCodes.Ldc_I4, i);
                        generator.Emit(OpCodes.Callvirt, getValueMethod);
                        //generator.Emit(OpCodes.Unbox_Any, propertyInfo.PropertyType);
                        generator.Emit(OpCodes.Unbox_Any, dataRecord.GetFieldType(i)); //拆箱
                        generator.Emit(OpCodes.Callvirt, propertyInfo.GetSetMethod());
                        generator.MarkLabel(endIfLabel);

                    }
                }
                generator.Emit(OpCodes.Ldloc, result);
                generator.Emit(OpCodes.Ret);
                dynamicBulider.hanlder = (Load)method.CreateDelegate(typeof(Load));
                return dynamicBulider;
            }

        }
    }
}
