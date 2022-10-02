<template lang="">
    <div class="combobox">
        <MInput :text="'text'" v-model="value" :rules="'required'" fieldName="Đơn vị" v-model:errMsg="depErrorClone"/>
        <button @click="clickShowDepartment" tabindex="-1">
            <div class="icon">
            </div>
        </button>
        <div class="data__table" v-if="isShowDepartment">
            <table class="dropdown-header" cellspacing="0" cellpadding="0">

                <tr class="text__align--left" style="background-color: #f0f0f0;">
                    <th style="width: 80px;">Mã
                         đơn vị</th>
                    <th>Tên đơn vị</th>
                </tr>

                <tbody>
                    <tr class="text__align--left" v-for="(department, index) in dataDepartment" :key="index" :class="{'row-active':  department[fieldKey] === itemSelected}" @click="selectDepartment(department)">
                        <td style="width: 80px;">{{department[fieldKey]}}</td>
                        <td>{{department[fieldName]}}</td>
                    </tr>
                </tbody>
            </table>
            <div class="dropdown-footer">
                <div class="btn-search">
                    <div class="m-icon-16 m-icon-pen"></div>
                    <div class="text">Cập nhật cơ cấu tổ chức</div>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
import { HTTP } from '@/api/http-common';
export default {
    name: "MComboboxDepartment",
    props: {
        fieldKey: {
                Type: String,
                default: "DepartmentCode",
            },
        fieldName: {
                Type: String,
                default: "DepartmentName",
            },
        error: {},
        departmentID: {
            type: [String, Number],
            default: null
         },
         departmentName: {
            type: [String, Number],
            default: null
         },
         departmentCode: {
            type: [String, Number],
            default: null
         },
         depError: {
            Type: String,
            default: ""
         }
    },
    created() {
        this.getAllDepartment();
    },
    computed: {
   
    },
    mounted() {
        this.depErrorClone = this.depError;
    },  
    // check value thay đổi sẽ search
    watch: {
            value(newval, oldval) {
                if(newval != oldval) {
                    if(newval){
                        this.dataDepartment = this.cloneData.filter((dep) => dep["DepartmentName"].toLowerCase().includes(newval.trim()));
                    }else{
                        this.dataDepartment = this.cloneData;
                    }
                }
            },
            depErrorClone(val) {
                this.$emit('update:depError',  this.depErrorClone);
            }
    },
    data() {
        return {
            isShowDepartment: false,
            dataDepartment: {},
            itemSelected: "",
            value: "",
            cloneData: [],
            depErrorClone: ""
        }
    },
    methods: {
        /**
         * Lấy ra tất cả thông tin đơn vị
         * Author: DXLOC 21/09/2022
         */
        getAllDepartment() {
            try {
                HTTP.get(`\Departments`)
                .then((res) => {
                    this.dataDepartment = res.data;
                    this.value = this.departmentName;
                    this.cloneData = [...res.data];
                })    
            } catch (error) {
                console.log(error);
            }
        },
        /**
         * Chọn đơn vị
         * Author: DXLOC 21/09/2022
         */
        selectDepartment(department) {
            this.itemSelected = department[this.fieldKey];
            this.value = department[this.fieldName]
            this.isShowDepartment = false; 
            this.$emit('update:departmentID', department?.DepartmenId);
            this.$emit('update:departmentCode', department?.DepartmentCode);
            this.$emit('update:departmentName', department?.DepartmentName);
        },
        /**
         * Hiển thị đơn vị
         * Author: DXLOC 21/09/2022
         */
        clickShowDepartment() {
            this.dataDepartment = this.cloneData;
            this.isShowDepartment = !this.isShowDepartment;
        },
        /**
         * Ấn ra ngoài sẽ tắt 
         * Author: DXLOC 21/09/2022
         */
        blurInput() {
            this.isShowDepartment = false;
        },
    }
}
</script>
<style scoped>
@import url(@/css/components/combobox.css);

.row-active {
    background-color: #2ca01c !important;
    color: #fff;
}
.dropdown-footer {
    background-color: #f0f0f0;
    height: 30px;
    padding: 2px 6px;
    line-height: 30px;
    /* display: flex;
        align-items: center;
        justify-content: center; */
}

.dropdown-footer .btn-search {
    display: flex;
    align-items: center;
    justify-content: flex-start;
    padding-left: 8px;
}

.dropdown-footer .text {
    color: #35bf22;
    padding-left: 6px;
}

.data__table {
    position: absolute;
    top: 100%;
    width: 100%;
    min-height: 100px;
    z-index: 10;
    margin-top: 4px;
    border: 1px solid #ccc;
    background-color: #fff;
}

table tr td,
th {
    border: none;
}

table tr th {
    text-transform: initial;
}

table tbody tr:hover {
    background-color: #f0f0f0 !important;
    color: #35bf22;
    cursor: pointer;
}

table tbody {
    overflow-y:auto;
}
table {
    width: 100%;
    border: none !important;
}

.dropdown-header tr {
    padding: 0 10px;
    height: 32px;
}

.dropdown-header td {
    height: 0;
}

.combobox {
    width: 390px;
}

.combobox input {
    width: calc(100% - 32px);
    padding: 0 0 0 10px;

}

.combobox button {
    width: 32px;
    border: none;
    padding: 0;
}

.combobox button .icon {
    background: url(@/assets/img/Sprites.64af8f61.svg) no-repeat -371px -364px;
    width: 10px;
    height: 8px;
}

.m-icon-pen {
    background: url(https://actappg1.misacdn.net/img/Sprites.79cca840.svg) no-repeat -2392px -404px;
}
</style>