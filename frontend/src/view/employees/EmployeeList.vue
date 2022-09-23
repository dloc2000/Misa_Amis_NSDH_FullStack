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
              v-on:input="filterByName"
            />
            <button
              class="page__toolbar--reload"
              @click="clickReloadPage"
            ></button>
            <div>
              <div class="input__icon-right"></div>
            </div>
          </div>
          <div class="page__table">
            <m-table :dataSource="employees" @emp-selected="dblShowForm">
              <template
              v-slot:customColumn="dataProps"  
              @click="console.log(dataProps)"
              >
              <span>{{formatGender(dataProps)}}</span>
              <!-- // dataProps["data"]== 1 ? "Nam" : "Nữ" -->
            </template>
            </m-table>
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
      @hide-form="closeFormEmployeeAndDialog"
      :employeeSelected="employeeSelected"
      @confirm-form="clickShowDialog"
      :formMode="formMode"
      @load-data="loadData"
      @load-toast="loadToast"
    />
    <MLoading v-if="isLoading" />
    <MDialog
      :dialogSelected="dialogSelected"
      v-if="isShowDialog"
      @hide-dialog="closeDialog"
      @hide-all="closeFormEmployeeAndDialog"
    />
    <MToast v-model="isToast"/>
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
  data() {
    return {
      employees: [],
      isLoading: false,
      isShowForm: false,
      isToast: false,
      isShowDialog: false,
      employeeSelected: {},
      htmlRow: [],
      formMode: 0,
      nameSearch: null,
      temp:null,
    };
  },
  watch:{
    isToast(val){
      console.log(val)
    }
  },
  computed: {
      
  },
  methods: {
    /**
     * hàm format gender trên client
     * @param {obj}  
     * Return : Nam hoặc Nữ hoặc " "
     * Author: DXLOC 22/09/2022
     */
    formatGender(obj) {
        if(obj) {
          var gender = obj["data"];
          if( gender == 1) {
              return "Nam"
          } else if(gender == 2) {
              return "Nữ"
          }
        } else return ""
      },
    /**
     * Btn reload trang
     * Author: DXLOC 15/09/2022
     */
    clickReloadPage() {
      this.loadData();
    },
    /**
     *  Btn "Thêm nhân viên" và hiện form
     * Author: DXLOC 16/09/2022
     */
    clickShowFormEmployee() {
      this.formMode = 1;
      this.isShowForm = true;
      this.employeeSelected = {};
    },
    /**
     * double click row và hiện form sửa
     * Author: DXLOC 16/09/2022
     */
    dblShowForm(obj) {
      this.formMode = 2;
      this.employeeSelected = obj;
      this.isShowForm = true;
    },
    /**
     * Btn đóng form nhân viên và dialog
     * Author: DXLOC 15/09/2022
     */
    closeFormEmployeeAndDialog() {
      this.isShowForm = false;
      this.isShowDialog = false;
      // this.loadData();
    },
    /**
     * Btn đóng Dialog
     * Author: DXLOC 15/09/2022
     */
    closeDialog() {
      this.isShowDialog = false;
    },
    /**
     * Btn xóa employee
     * Author: DXLOC 17/09/2022
     */
    clickDeleteEmployee() {
      this.isShowDialog = true;
    },
    clickShowDialog() {
      this.isShowDialog = true;
    },
    /**
     * Lọc dữ liệu theo tên
     * Author : Locdx 16/09/2022
     */
    filterByName() {
      try {
        clearTimeout(this.temp);
        this.temp = setTimeout(() => {
          HTTP.get(`/employees/filter?employeeFilter=${this.nameSearch}`).then((res) => {
            this.employees = [];
            setTimeout(()=>{
              this.employees = res.data.Data;
            },0)
          });
        }, 300);
      } catch (error) {
          console.log(error);
      }
    },
    loadToast(){
      this.isToast = true;
    },
    /**
     * Lấy tất cả thông tin nhân viên load lên table
     * Author : Locdx 13/09/2022
     */
    loadData() {
      try {
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
      } catch (error) {
        console.log(error);
      }
    },
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
