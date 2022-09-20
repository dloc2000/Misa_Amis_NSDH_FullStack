<template>
  <div class="tag-as-parent">
    <div class="main__page">
      <div class="page__header">
        <div class="page__header-title">Nhân viên</div>
        <MButton
          :classBtn="['button1']"
          :text="'Thêm mới nhân viên'"
          @click="clickShowFormEmployee"
        />
      </div>
      <div class="page__content">
        <div class="page__group">
          <div class="page__toolbar">
            <input
              type="text"
              class="page__toolbar--input input input-placehoder__italic"
              placeholder="Tìm theo mã, tên nhân viên"
              v-model="this.nameSearch"
              @change="filterByName"
            />
            <button
              id="btnReload"
              class="page__toolbar--reload"
              @click="clickReloadPage"
            ></button>
            <div>
              <div class="input__icon-right"></div>
            </div>
          </div>
          <div class="page__table">
            <m-table :dataSource="employees" @emp-selected="dblShowForm"></m-table>
          </div>
        </div>
        <div class="page__footer">
          <div class="page__total-record">
            Tổng số:<b> {{ this.employees.length }}</b> bản ghi
          </div>
          <div class="page__pagingation">
            <MCombobox />
            <MPaging />
          </div>
        </div>
      </div>
    </div>
    <EmployeeDetail
      v-if="isShowForm"
      ref="detail"
      @hide-form="closeFormEmployeeAndDialog"
      :employeeSelected="employeeSelected"
      @confirm-form="clickShowDialog"
      :formMode="formMode"
    />
    <MLoading v-if="isLoading" />
    <MDialog
      :dialogSelected="dialogSelected"
      v-if="isShowDialog"
      @hide-dialog="closeDialog"
      @hide-all="closeFormEmployeeAndDialog"
    />
  </div>
</template>

<script>
/**
 * Bảng danh sách thông tin nhân viên
 * Author : Locdx 13/09/2022
 */
import EmployeeDetail from "./EmployeeDetail.vue";
import MLoading from "@/components/base/loading/MLoading.vue";
import MDialog from "@/components/base/dialog/MDialog.vue";
import MPaging from "@/components/base/paging/MPaging.vue";
import MCombobox from "@/components/base/combobox/MCombobox.vue";
import { HTTP } from "../../api/http-common";
export default {
  name: "EmployeeList",
  created() {
    this.loadData();
  },
  props: {},
  methods: {
    // click reload page
    clickReloadPage() {
      this.loadData();
    },
    // click "Thêm nhân viên" và hiện form
    clickShowFormEmployee() {
      this.formMode = 1;
      // this.$refs.detail.inputFocus();
      this.isShowForm = true;
      this.employeeSelected = {};
    },
    // dblclick show form
    dblShowForm(obj) {
      this.formMode = 2;
      this.employeeSelected = obj;
      this.isShowForm = true;
    },
    // Đóng form nhân viên và dialog
    closeFormEmployeeAndDialog() {
      this.isShowForm = false;
      this.isShowDialog = false;
      // this.loadData();
    },
    // Đóng Dialog
    closeDialog() {
      this.isShowDialog = false;
    },
    // Xóa nhân viên
    clickDeleteEmployee() {
      this.isShowDialog = true;
    },
    clickShowDialog() {
      this.isShowDialog = true;
    },
    // Lọc dữ liệu
    filterByName() {
      clearTimeout(temp);
      var temp = setTimeout(() => {
        HTTP.get(`/employees/filter?employeeFilter=${this.nameSearch}`).then((res) => {
          this.employees = [];
          this.employees = res.data.Data;
        }, 500);
      });
    },
    // Load data lên table
    loadData() {
      //Loading dữ liệu
      this.isLoading = true;
      // Call API lấy tất cả các nhân viên = Axios.
      HTTP.get(`/employees`)
        .then((reponse) => {
          this.employees = reponse.data;
          this.isLoading = false;
        })
        .catch((error) => {
          console.log(error);
          this.loading = false;
        });
    },
  },
  data() {
    return {
      employees: [],
      isLoading: false,
      isShowForm: false,
      isShowDialog: false,
      employeeSelected: {},
      htmlRow: [],
      formMode: 0,
      nameSearch: null,
    };
  },
  components: { EmployeeDetail, MLoading, MDialog, MPaging, MCombobox },
};
</script>

<style>
.tag-as-parent {
  width: 100%;
  height: 100%;
}
</style>
