using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MusicApp.Logic
{
    public static class ResourceManager<T> where T: class
    {
        /// <summary>
        /// Find a resource with a given name in a given ResourceDictionary and all embedded ResourceDictionaries
        /// </summary>
        /// <param name="dynamicResource">ResourceDictionary in which will search for a resource</param>
        /// <param name="findName">Name that will look for</param>
        /// <returns>Return a found value of type T or null</returns>
        public static T FindInResourceByNameSingleOrDefault(ResourceDictionary dynamicResource, string findName)
        {
            if (dynamicResource.Contains(findName) && (dynamicResource[findName] is T))
                return dynamicResource[findName] as T;


            foreach (ResourceDictionary mergedRes in dynamicResource.MergedDictionaries)
            {
                var buffer = FindInResourceByNameSingleOrDefault(mergedRes, findName);
                if ((buffer != null) && (buffer is T))
                    return buffer as T;
            }

            return null;
        }

        /// <summary>
        /// Find a resource with a given name in a given ResourceDictionary, application's resources and all embedded ResourceDictionaries
        /// </summary>
        /// <param name="dynamicResource">ResourceDictionary in which will search for a resource</param>
        /// <param name="findName">Name that will look for</param>
        /// <returns>Return a found value of type T or null</returns>
        public static T FindInAllResourcesByNameSingleOrDefault(ResourceDictionary dynamicResource, string findName)
        {
            T buffer = FindInResourceByNameSingleOrDefault(Application.Current.Resources, findName);
            if (buffer != null)
                return buffer;

            buffer = FindInResourceByNameSingleOrDefault(dynamicResource, findName);
            if (buffer != null)
                return buffer;

            return null;
        }

        /// <summary>
        /// Find a resource with a given name in a given ResourceDictionary and all embedded ResourceDictionaries
        /// </summary>
        /// <param name="dynamicResource">ResourceDictionary in which will search for a resource</param>
        /// <param name="findName">Name that will look for</param>
        /// <returns>Return a found value of type T</returns>
        public static T FindInResourceByNameSingle(ResourceDictionary dynamicResource, string findName)
        {
            T buffer = FindInResourceByNameSingleOrDefault(dynamicResource, findName);
            if (buffer != null)
                return buffer;

            throw new Exception(String.Format("Resource by name {0} was not found", findName));
        }

        /// <summary>
        /// Find a resource with a given name in a given ResourceDictionary, application's resources and all embedded ResourceDictionaries
        /// </summary>
        /// <param name="dynamicResource">ResourceDictionary in which will search for a resource</param>
        /// <param name="findName">Name that will look for</param>
        /// <returns>Return a found value of type T</returns>
        public static T FindInAllResourceByNameSingle(ResourceDictionary dynamicResource, string findName)
        {
            T buffer = FindInAllResourcesByNameSingleOrDefault(dynamicResource, findName);
            if (buffer != null)
                return buffer;

            throw new Exception(String.Format("Resource by name {0} was not found", findName));
        }
    }
}
