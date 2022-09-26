var MISAResource = {

    /**
     * Câu cảnh báo cho người dùng nếu nhập thiếu trường quan trọng
     * Author: DXLOC 15/09/2022
     */
    ErrorValidate: {
        EmployeeCodeNotEmpty: {
            VI: "Mã nhân viên không được phép để trống",
            EN: "Employee Code is not empty"
        },
        FullNameNotEmpty: {
            VI: "Tên không được phép để trống",
            EN: "Full name not Empty."
        },
        DepartmentNotEmpty: {
            VI: "Đơn vị không được phép để trống",
            EN: "Department not Empty."
        },
      
    },

    /**
     * Câu thông báo cho người dùng 
     * Author: DXLOC 15/09/2022
     */
    MessageDialog: {
        success: {
            VI: "Thành công",
            EN:  "success"
        },
        error: {
            VI: "Đã xảy ra lỗi vui lòng liên hệ CSKH Misa để được hỗ trợ",
            EN: ""
        },
        exists: {
            VI: "Mã nhân viên đã tồn tại trong hệ thống",
            EN: ""
        },
        confirm: {
            VI: "Dữ liệu đã bị thay đổi bạn có muốn cất không?",
            EN: ""
        },
        delete: {
            VI: "Bạn có thực sự muốn xóa nhân viên không?",
            EN: "Bạn có thực sự muốn xóa nhân viên không?"
        },
        deletes: {
            VI: "Bạn có thực sự muốn xóa hàng loạt nhân viên không?",
            EN: "Bạn có thực sự muốn xóa hàng loạt nhân viên không?"
        }
    }

}
export default MISAResource;