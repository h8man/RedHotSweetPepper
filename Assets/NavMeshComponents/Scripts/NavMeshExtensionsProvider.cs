using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavMeshComponents.Extensions
{
    public interface INavMeshExtensionsProvider
    {
        int Count { get; }
        NevMeshExtension this[int index] { get; }
        void Add(NevMeshExtension extension, int order);
        void Remove(NevMeshExtension extension);
    }
    internal class NavMeshExtensionMeta
    {
        public int order;

        public NavMeshExtensionMeta(int order, NevMeshExtension extension)
        {
            this.order = order;
            this.extension = extension;
        }

        public NevMeshExtension extension;
    }
    internal class NavMeshExtensionsProvider : INavMeshExtensionsProvider
    {
        List<NavMeshExtensionMeta> _extensions = new List<NavMeshExtensionMeta>();
        static Comparer<NavMeshExtensionMeta> Comparer = Comparer<NavMeshExtensionMeta>.Create((x, y) => x.order > y.order ? 1 : x.order < y.order ? -1 : 0);
        public NevMeshExtension this[int index] => _extensions[index].extension;

        public int Count => _extensions.Count;

        public void Add(NevMeshExtension extension, int order)
        {
            var meta = new NavMeshExtensionMeta(order, extension);
            var at = _extensions.BinarySearch(meta, Comparer);
            if (at < 0)
            {
                _extensions.Add(meta);
                _extensions.Sort(Comparer);
            }
            else
            {
                _extensions.Insert(at, meta);
            }
        }

        public void Remove(NevMeshExtension extension)
        {
            _extensions.RemoveAll(x => x.extension = extension);
        }
    }
}
