using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace Commons
{
    public static class DefaultIcons
    {
        private static readonly Lazy<Icon> _lazyFolderIcon = new Lazy<Icon>(FetchIcon, true);
        private static readonly Lazy<Icon> _lazyFolderOpenIcon = new Lazy<Icon>(FetchOpenIcon, true);

        public static Icon FolderLarge
        {
            get { return _lazyFolderIcon.Value; }
        }

        public static Icon FolderOpenLarge
        {
            get { return _lazyFolderOpenIcon.Value; }
        }

        private static Icon FetchIcon()
        {
            var tmpDir = Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString())).FullName;
            var icon = ExtractFromPath(tmpDir);
            Directory.Delete(tmpDir);
            return icon;
        }

        private static Icon FetchOpenIcon()
        {
            var tmpDir = Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString())).FullName;
            var icon = ExtractFromPath(tmpDir, true);
            Directory.Delete(tmpDir);
            return icon;
        }

        public static Icon ExtractFromPath(string path, bool isOpen = false)
        {
            SHFILEINFO shinfo = new SHFILEINFO();
            SHGetFileInfo(
                path,
                0, ref shinfo, (uint)Marshal.SizeOf(shinfo),
                SHGFI_ICON | SHGFI_LARGEICON | SHGFI_ATTRIBUTES | (isOpen == true ? SHGFI_OPENICON : 0x00));
            return System.Drawing.Icon.FromHandle(shinfo.hIcon);
        }

        //Struct used by SHGetFileInfo function
        [StructLayout(LayoutKind.Sequential)]
        private struct SHFILEINFO
        {
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        };

        [DllImport("shell32.dll")]
        private static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);

        private const uint SHGFI_ICON = 0x000000100;
        private const uint SHGFI_DISPLAYNAME = 0x000000200;
        private const uint SHGFI_TYPENAME = 0x000000400;
        private const uint SHGFI_ATTRIBUTES = 0x000000800;
        private const uint SHGFI_ICONLOCATION = 0x000001000;
        private const uint SHGFI_EXETYPE = 0x000002000;
        private const uint SHGFI_SYSICONINDEX = 0x000004000;
        private const uint SHGFI_LINKOVERLAY = 0x000008000;
        private const uint SHGFI_SELECTED = 0x000010000;
        private const uint SHGFI_ATTR_SPECIFIED = 0x000020000;
        private const uint SHGFI_LARGEICON = 0x000000000;
        private const uint SHGFI_SMALLICON = 0x000000001;
        private const uint SHGFI_OPENICON = 0x000000002;
        private const uint SHGFI_SHELLICONSIZE = 0x000000004;
        private const uint SHGFI_PIDL = 0x000000008;
        private const uint SHGFI_USEFILEATTRIBUTES = 0x000000010;
        private const uint SHGFI_ADDOVERLAYS = 0x000000020;
        private const uint SHGFI_OVERLAYINDEX = 0x000000040;

    }
}
