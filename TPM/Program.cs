// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;
using CacKhuyenMaiDangChay;
Console.WriteLine("[The Main Program]");

RuntimeHelpers.RunClassConstructor(typeof(HoaDon.Service).TypeHandle);
RuntimeHelpers.RunClassConstructor(typeof(CuaHang.Service).TypeHandle);
RuntimeHelpers.RunClassConstructor(typeof(LenDonHang.LenDonHangService).TypeHandle);
ServiceCacKhuyenMaiDangChay.Instance.Init();
