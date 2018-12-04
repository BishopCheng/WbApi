using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace Configs
{
    /// <summary>
    /// 配置读取类（注入方式）
    /// 作者：程淮榕
    /// 日期：2018-12-04
    /// </summary>
    public class AppConfigurationService
    {
        /// <summary>
        /// 获取配置
        /// </summary>
        /// <typeparam name="T">配置类型实体</typeparam>
        /// <param name="key">键</param>
        /// <param name="settingFilePath">设置路径</param>
        /// <returns></returns>
        public T GetAppSetting<T>(string key,string settingFilePath) where T:class,new()
        {
            //建立一个新的配置项
            IConfiguration configuration = new ConfigurationBuilder()
            .Add(new JsonConfigurationSource { Path = settingFilePath, ReloadOnChange = true })
            .Build();

            var appconfig = new ServiceCollection()
            .AddOptions()
            .Configure<T>(configuration.GetSection(key))
            .BuildServiceProvider()
            .GetService<IOptions<T>>()
            .Value;

            return appconfig;
        }

    }
}
