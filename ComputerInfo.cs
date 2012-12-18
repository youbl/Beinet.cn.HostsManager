using System;
using System.Management;
using Microsoft.Win32;

namespace Beinet.cn.HostsManager
{
    /// <summary>
    /// 返回当前计算机相关信息
    /// </summary>
    public class ComputerInfo
    {
        private static ComputerInfo _instance;

        /// <summary>
        /// 返回唯一实例
        /// </summary>
        /// <returns></returns>
        public static ComputerInfo Instance()
        {
            return _instance ?? (_instance = new ComputerInfo());
        }

        /// <summary>
        /// Cpu ID
        /// </summary>
        public string CpuID
        {
            get
            {
                try
                {
                    //获取CPU序列号代码
                    string cpuInfo = "";//cpu序列号
                    using (ManagementClass mc = new ManagementClass("Win32_Processor"))
                    using (ManagementObjectCollection moc = mc.GetInstances())
                    {
                        foreach (ManagementObject mo in moc)
                            cpuInfo += mo.Properties["ProcessorId"].Value + ";";
                    }
                    return cpuInfo;
                }
                catch
                {
                    return "unknow";
                }
            }
        }

        /// <summary>
        /// 获取Cpu频率
        /// </summary>
        /// <returns></returns>
        public string CpuFrequency
        {
            get
            {
                try
                {
                    RegistryKey rk = Registry.LocalMachine.OpenSubKey(@"HARDWARE\DESCRIPTION\System\CentralProcessor\0");
                    long f = (int) rk.GetValue("~MHz");
                    if(f<1000)
                        return f + "MHz";
                    return (f/1000d).ToString("N2") + "GHz";
                }
                catch
                {
                    return "unknown";
                }
            }
        }

        /// <summary>
        /// MAC
        /// </summary>
        public string IpAddress
        {
            get
            {
                try
                {
                    //获取网卡Mac地址
                    string mac = "";
                    using (ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration"))
                    using (ManagementObjectCollection moc = mc.GetInstances())
                    {
                        foreach (ManagementObject mo in moc)
                            if ((bool)mo["IPEnabled"])
                            {
                                mac += "MAC:" +mo["MacAddress"] + ",IP:" + ((Array)(mo.Properties["IpAddress"].Value)).GetValue(0)+"; ";
                            }
                    }
                    return mac;
                }
                catch
                {
                    return "unknow";
                }
            }
        }

        /// <summary>
        /// 磁盘ID
        /// </summary>
        /// <returns></returns>
        public string DiskID
        {
            get
            {
                try
                {
                    //获取硬盘ID
                    String HDid = "";
                    using (ManagementClass mc = new ManagementClass("Win32_DiskDrive"))
                    using (ManagementObjectCollection moc = mc.GetInstances())
                    {
                        foreach (ManagementObject mo in moc)
                            HDid += (string)mo.Properties["Model"].Value + ";";
                    }
                    return HDid;
                }
                catch
                {
                    return "unknow";
                }
            }
        }

        /// <summary>
        /// 磁盘空间
        /// </summary>
        public string DiskSpace
        {
            get
            {
                try
                {
                    //ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"d:\"");
                    //disk.Get();
                    //string totalByte = disk["FreeSpace"].ToString();
                    //long freeDiskSpaceMb = Convert.ToInt64(totalByte) / 1024 / 1024;
                    //return freeDiskSpaceMb;
                    string ret = "";
                    SelectQuery selectQuery = new SelectQuery("select * from win32_logicaldisk");
                    ManagementObjectSearcher searcher = new ManagementObjectSearcher(selectQuery);
                    foreach (ManagementObject disk in searcher.Get())
                    {
                        #region 遍历ManagementObject的属性 注释代码
                        
                        //foreach (PropertyData property in disk.Properties)
                        //{
                        //    ret += property.Name + ":" + property.Value + ";";
                        /*
Access:
Availability:
BlockSize:
Caption:C:
Compressed:False
ConfigManagerErrorCode:
ConfigManagerUserConfig:
CreationClassName:Win32_LogicalDisk
Description:本地固定磁盘
DeviceID:C:
DriveType:3
ErrorCleared:
ErrorDescription:
ErrorMethodology:
FileSystem:NTFS
FreeSpace:31024824320
InstallDate:
LastErrorCode:
MaximumComponentLength:255
MediaType:12
Name:C:
NumberOfBlocks:
PNPDeviceID:
PowerManagementCapabilities:
PowerManagementSupported:
ProviderName:
Purpose:
QuotasDisabled:True
QuotasIncomplete:False
QuotasRebuilding:False
Size:57922387968
Status:
StatusInfo:
SupportsDiskQuotas:True
SupportsFileBasedCompression:True
SystemCreationClassName:Win32_ComputerSystem
SystemName:WX-2304-5440
VolumeDirty:False
VolumeName:
VolumeSerialNumber:D04F3EC3
*/
                        //}
                        #endregion

                        string size = string.Empty;
                        string free = string.Empty;
                        if (disk["Size"] != null)
                            size = "大小:" + GetDiskSizeString((ulong)disk["Size"]);
                        if (disk["FreeSpace"] != null)
                            free = "可用空间:" + GetDiskSizeString((ulong)disk["FreeSpace"]);

                        ret += string.Format("磁盘{0} {1},文件系统:{2};{3} {4}\r\n",
                                             disk["Name"], disk["Description"], disk["FileSystem"], size, free);
                    }
                    return ret;
                }
                catch
                {
                    return "unknown";
                }
            }
        }

        /// <summary>
        /// 操作系统的登录用户名
        /// </summary>
        /// <returns></returns>
        public string LoginUserName
        {
            get
            {
                try
                {
                    string st = "";
                    using (ManagementClass mc = new ManagementClass("Win32_ComputerSystem"))
                    using (ManagementObjectCollection moc = mc.GetInstances())
                    {
                        foreach (ManagementObject mo in moc)
                            st += mo["UserName"] + ";";
                    }
                    return st;
                }
                catch
                {
                    return "unknow";
                }
            }
        }

        /// <summary>
        /// PC类型
        /// </summary>
        /// <returns></returns>
        public string SystemType
        {
            get
            {
                try
                {
                    string st = "";
                    using (ManagementClass mc = new ManagementClass("Win32_ComputerSystem"))
                    using (ManagementObjectCollection moc = mc.GetInstances())
                    {
                        foreach (ManagementObject mo in moc)
                            st += mo["SystemType"] + ";";
                    }
                    return st;
                }
                catch
                {
                    return "unknow";
                }
            }
        }

        /// <summary>
        /// 物理内存
        /// </summary>
        /// <returns></returns>
        public string TotalPhysicalMemory
        {
            get
            {
                try
                {
                    using (ManagementClass mc = new ManagementClass("Win32_ComputerSystem"))
                    using (ManagementObjectCollection moc = mc.GetInstances())
                    {
                        foreach (ManagementObject mo in moc)
                        {
                            long m = Convert.ToInt64(mo["TotalPhysicalMemory"]);
                            return GetDiskSizeString(m);
                        }
                    }
                }
                catch
                {
                }
                return "unknown";
            }
        }

        /// <summary>
        /// 计算机名称
        /// </summary>
        /// <returns></returns>
        public string ComputerName
        {
            get
            {
                try
                {
                    return Environment.GetEnvironmentVariable("ComputerName");
                }
                catch
                {
                    return "unknow";
                }
            }
        }

        string GetDiskSizeString(long size)
        {
            if (size < 1024)
                return size.ToString("N0") + "B";
            int b = 0;
            double d = size / 1024d;
            while (d >= 1024)
            {
                b++;
                d = d / 1024d;
            }
            return d.ToString("N") + new[] { "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB", "NB", "DB" }[b];
        }

        string GetDiskSizeString(ulong size)
        {
            return GetDiskSizeString((long) size);
        }
    }
}