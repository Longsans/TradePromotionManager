// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;
using System.Text.Json;

Console.WriteLine("[The Main Program]");

RuntimeHelpers.RunClassConstructor(typeof(MatHang.MatHangService).TypeHandle);

RuntimeHelpers.RunClassConstructor(typeof(HoaDon.Service).TypeHandle);
RuntimeHelpers.RunClassConstructor(typeof(CuaHang.Service).TypeHandle);
RuntimeHelpers.RunClassConstructor(typeof(LenDonHang.LenDonHangService).TypeHandle);

var res = 
    MatHang.MatHangService.EditMatHang(
        "abcd",
        new Dictionary<string, object>()
        {
            {"dungTich", 12 },
            {"donVi", 1234 },
            {"holyShit", "boyo" },
        }
    );

Console.WriteLine(res);

RuntimeHelpers.RunClassConstructor(typeof(CacKhuyenMaiDangChay.Service).TypeHandle);
RuntimeHelpers.RunClassConstructor(typeof(CacKhuyenMaiHoanThanh.Service).TypeHandle);
RuntimeHelpers.RunClassConstructor(typeof(PhanTichKhuyenMai.Service).TypeHandle);
RuntimeHelpers.RunClassConstructor(typeof(LenKeHoachKhuyenMai.Service).TypeHandle);

LenKeHoachKhuyenMai.Service.PostToCacKhuyenMaiDangChayService();
CacKhuyenMaiDangChay.Service.PostToCacKhuyenMaiHoanThanhService();
PhanTichKhuyenMai.Service.GetCacKhuyenMaiHoanThanh();
