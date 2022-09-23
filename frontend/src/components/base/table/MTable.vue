<template>
  <div class="table__content">
    <table id="tbEmployeeList" class="table">
      <thead>
        <tr>
          <th class="text__align--center" style="min-width: 40px">
            <input type="checkbox" />
          </th>
          <th
            v-for="(item, index) in headers"
            :key="index"
            :class="item.className"
            :style="{ 'min-width': item.Width + 'px' }"
          >
            {{ item.Caption }}
          </th>
          <th class="text__align--center" style="min-width: 120px">
            Chức năng
          </th>
        </tr>
      </thead>
      <tbody>
        <tr
          v-for="(emp, index) in dataSource"
          :key="emp.EmployeeId"
          :class="{ 'row--selected': index === indexRow }"
          @click="clickSelectedRow(index)"
          @dblclick.stop="rowDoubleClick(emp)"
        >
          <td><input type="checkbox" /></td>
          <td v-for="item in headers">
            <span v-if="item.type == 1">
              {{ emp[item.Field] ? emp[item.Field] : "" }}
            </span>
            <span v-else-if="item.type == 2">
              {{ emp[item.Field] ? Common.formatDate(emp[item.Field]) : "" }}
            </span>
            <span v-else-if="item.type == 3">
              <slot name="customColumn" :data="emp[item.Field]"></slot>
            </span>
          </td>
          <td>
              <MOptions />
          </td>
        </tr>
        <!-- <tr class="row--selected">
                                                <td id="EmployeeCode"class="text__align--center no_padding" style="min-width: 40px;">
                                                    <input type="checkbox">
                                                </td>
                                                <td class="text__align--left" style="min-width: 150px;">001200</td>
                                                <td class="text__align--left" style="min-width: 250px;">Nguyễn Văn Vũ</td>
                                                <td class="text__align--left" style="min-width: 120px;">Nam</td>
                                                <td class="text__align--center" style="min-width: 120px;">01/01/1990</td>
                                                <td class="text__align--left" style="min-width: 200px;">001200066666</td>
                                                <td class="text__align--left" style="min-width: 250px;">Nhân viên</td>
                                                <td class="text__align--left" style="min-width: 250px;">Nhóm kiểm hàng</td>
                                                <td class="text__align--left" style="min-width: 150px;">Số tài khoản</td>
                                                <td class="text__align--left" style="min-width: 250px;">Tên ngân hàng</td>
                                                <td class="text__align--left" style="min-width: 250px;">Chi nhánh TK ngân hàng</td>
                                                <td class="text__align--center" style="min-width: 120px;">
                                                        
                                                </td>
                                            </tr> -->
      </tbody>
    </table>
  </div>
</template>
<script>
import common from "@/common/common.js";
export default {
  name: "MTable",
  props: {
    showCheckBox: {
      Type: Boolean,
      default: true,
    },
    dataSource: {
      Type: Array,
      default: () => [],
    },
    headers: {
      Type: Array,
      default: () => [
        {
          Caption: "Mã nhân viên",
          Field: "EmployeeCode",
          Width: 150,
          className: "text__align--left",
          type: 1, // 1- text, 2 -date, 3-datetime, 4- time
        },
        {
          Caption: "Tên nhân viên",
          Field: "FullName",
          Width: 250,
          className: "text__align--left",
          type: 1,
        },
        {
          Caption: "Giới tính",
          Field: "Gender",
          Width: 120,
          className: "text__align--left",
          type: 3,
        },
        {
          Caption: "Ngày sinh",
          Field: "DateOfBirth",
          Width: 120,
          className: "text__align--center",
          type: 2,
        },
        {
          Caption: "Số CMND",
          Field: "IdentifyNumber",
          Width: 200,
          className: "text__align--left",
          type: 1,
        },
        {
          Caption: "Chức danh",
          Field: "PostitionName",
          Width: 250,
          className: "text__align--left",
          type: 1,
        },
        {
          Caption: "Tên đơn vị",
          Field: "DepartmentName",
          Width: 250,
          className: "text__align--left",
          type: 1,
        },
        {
          Caption: "Số tài khoản",
          Field: "EmployeeCode",
          Width: 150,
          className: "text__align--left",
          type: 1,
        },
        {
          Caption: "Tên ngân hàng",
          Field: "EmployeeCode",
          Width: 250,
          className: "text__align--left",
          type: 1,
        },
        {
          Caption: "Chi nhánh TK ngân hàng",
          Field: "EmployeeCode",
          Width: 250,
          className: "text__align--left",
          type: 1,
        },
      ],
    },
  },
  data() {
    return {
      indexRow: 0,
      employeeSelected: {},
      Common: common,
    };
  },
  computed: {
    convertGender() {
      if (true) {
      }
    },
  },
  methods: {
    // click chọn hàng của table
    clickSelectedRow(index) {
      this.indexRow = index;
    },
    // Double click row sẽ hiện form sửa
    rowDoubleClick(emp) {
      this.$emit("emp-selected", emp);
    },
  },
};
</script>
<style>
@import url("@/css/components/table.css");
</style>
