using CodingPluginInterface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CRUD
{
    public class CodingPlugins
    {
        private readonly string pluginPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Plugins");
        public List<ICodingPlugin> plugins = new List<ICodingPlugin>();
        public void RefreshPlugins()
        {
            DirectoryInfo pluginDirectory = new DirectoryInfo(pluginPath);
            if (!pluginDirectory.Exists)
                pluginDirectory.Create();
     
            string[] pluginFiles = Directory.GetFiles(pluginPath, "*.dll");
            foreach (var file in pluginFiles)
            {
                Assembly asm = Assembly.LoadFrom(file);
                IEnumerable<ICodingPlugin> types = asm.GetTypes().
                                Where(t => t.GetInterface(nameof(ICodingPlugin)) != null)
                                .Select(x => Activator.CreateInstance(x))
                                .Cast<ICodingPlugin>();
                                //Where(i => i.FullName == typeof(ICodingPlugin).FullName).Any());
                
                foreach (var type in types)
                {
                    ICodingPlugin plugin = asm.CreateInstance(type.FullName) as ICodingPlugin;
                    plugins.Add(plugin);
                }
            }
        }
    }
}