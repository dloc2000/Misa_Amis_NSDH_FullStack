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
            <MButton :text="'Thực hiện hàng loạt'" :classBtn="'btn-bluk'" @click="isShowDeleteBluk = !isShowDeleteBluk"/>
            <div class="delete-bluk" v-if="isShowDeleteBluk" @click="isShowDialogs = !isShowDialogs">Xóa</div>
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
            <m-table :dataSource="employees" @emp-selected="dblShowForm" ref="table">
              <template
              v-slot:customColumn="dataProps"  
              @click="console.log(dataProps)"
              >
              <span>{{formatGender(dataProps)}}</span>
            </template>
            </m-table>
          </div>
        </div>
        <div class="page__footer">
          <div class="page__total-record">
            Tổng số:<b> {{ this.dataPaging.TotalRecord }}</b> bản ghi
          </div>
          <div class="page__pagingation">
            <MCombobox ref="combobox"/>
            <MPaging @on-paging="pagingData" :dataPaging="dataPaging"/>
            <!-- :pageSize="pageSize" :pageNumber="pageNumber" -->
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
      v-if="isShowDialog"
      @hide-dialog="closeDialog"
      @hide-all="closeFormEmployeeAndDialog"
      :formMode="formMode"
      @delete-emp="deleteData"
    />
    <MDialogs v-if="isShowDialogs" @hide-alls="closeDialog" @delete-all="onDeleteBluk" @hide-dialogs="closeFormEmployeeAndDialog"/>
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
      employeesDelete: [],
      isShowDeleteBluk: false,
      isLoading: false,
      isShowForm: false,
      isToast: false,
      isShowDialog: false,
      isShowDialogs: false,
      employeeSelected: {},
      htmlRow: [],
      formMode: 0,
      nameSearch: null,
      temp:null,
      pageSize: 20,
      pageNumber: 1,
      dataPaging: {
        TotalRecord: 0,
        TotalPage: 0,
        CurrentPage: 0,
        CurrentPageRecords: 0
      }
    };
  },
  watch:{
   
  },
  mounted() {
    this.dataPaging.TotalRecord = this.employees.length;
    this.emitter.on("popup-delete", (emp) => {
        this.employeeSelected = emp,
        this.isShowDialog = true,
        this.formMode = 0;
    });
  },
  methods: {
    /**
     * Thực hiện xóa nhiều bản ghi
     * Author: DXLOC 24/09/2022
     */
     onDeleteBluk() {
        try {
          this.employeesDelete = this.$refs.table.getEmployeesDelete();
          var emps = this.employeesDelete
            if(emps) {
              for (let i = 0 ; i < emps.length ; i++) {
                  var employeeId = emps[i].EmployeeId
                  HTTP.delete(`/employees/${employeeId}`)
                  .then((res) => {
                    if(i == (emps.length -1)) {
                      this.loadData();
                      this.isShowDialogs = false;
                      this.isShowDeleteBluk = false;
                    }
                  })
                }
              }
        } catch (error) {
          console.log(error);
        }
     },
     /**
     * Phân trang dữ liệu
     * Author: 23/09/2022
     */
     pagingData(pageNumber) {
        try {
          if(pageNumber) {
            this.pageNumber = pageNumber;
          }
          this.pageSize = this.$refs.combobox.clickSelectItem();
          this.isLoading = true
          HTTP.get(`/employees/filter?pageSize=${this.pageSize}&pageNumber=${this.pageNumber}`)
          .then((res) => {
               this.employees = res.data.Data
               this.dataPaging = {
                TotalPage: res.data.TotalPage,
                CurrentPage: res.data.CurrentPage,
                TotalRecord: res.data.TotalRecord
               }
               this.isLoading = false
            })
        } catch (error) {
            console.log(error);
        }
    },
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
      this.isShowDialogs = false;
      this.isShowDeleteBluk = false;
      // this.loadData();
    },
    /**
     * Btn đóng Dialog
     * Author: DXLOC 15/09/2022
     */
    closeDialog() {
      this.isShowDialog = false;
      this.isShowDialogs = false;
      this.isShowDeleteBluk = false;
    },
    /**
     * Btn xóa employee
     * Author: DXLOC 17/09/2022
     */
    clickDeleteEmployee() {
      this.isShowDialog = true;
    },
    /**
     * Bật toast msg 
     * Author : Locdx 22/09/2022
     */
    loadToast(){
      
      this.isToast = true;
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
   /**
     * Xóa nhân viên
     * Author : Locdx 16/09/2022
     */
    deleteData() {
        try {
          //Loading dữ liệu
            this.isLoading = true;
            this.isShowDialog = false;
             // Call API xóa 1 nhân viên = Axios.
            HTTP.delete(`/employees/${this.employeeSelected.EmployeeId}`)
            .then((res) => {
              this.loadData();
              this.isLoading = false;
              this.isToast = true;
            })
        } catch (error) {
          console.log(error)
        }
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

  components: { EmployeeDetail, MLoading, MPaging, MCombobox },
};
</script>

<style scoped>
.tag-as-parent {
  width: 100%;
  height: 100%;
}
.btn-bluk {
    position: absolute;
    left: 20px;
    color: #111;
    border-radius: 30px;
    border: 2px solid #3b3c3f;
    background-color: #fff;
    font-weight: 700;
    padding: 0 16px;
}
.btn-bluk:hover {
  background-color: #d2d3d6;
}
.delete-bluk {
    position: absolute;
    top: 52px;
    left: 110px;
    width: 80px;
    height: 18px;
    background-color: inherit;
    padding: 5px 10px;
    text-align: left;
    line-height: 18px;
    z-index: 3;
    cursor: pointer;
    border: 1px solid #ccc;
    transition: all 0.2 ease;
}
.delete-bluk:hover {
  background-color: #e8e9ec;
  color: #111;
}
</style>
