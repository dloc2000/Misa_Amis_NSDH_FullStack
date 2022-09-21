<template lang="">
    <div class="combobox">
        <input type="text">
        <button @click="isShowDepartment = !isShowDepartment">
            <div class="icon">
            </div>
        </button>
        <div class="data__table" v-if="isShowDepartment">
            <table class="dropdown-header" cellspacing="0" cellpadding="0">

                <tr class="text__align--left" style="background-color: #f0f0f0;">
                    <th style="width: 80px;">Mã đơn vị</th>
                    <th>Tên đơn vị</th>
                </tr>

                <tr class="text__align--left">
                    <td style="width: 80px;">DV03</td>
                    <td>Dv05</td>
                </tr>
                <tr class="text__align--left">
                    <td style="width: 80px;">DV03</td>
                    <td>Dv05</td>
                </tr>
                <tr class="text__align--left">
                    <td style="width: 80px;">DV03</td>
                    <td>Dv05</td>
                </tr>

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
export default {
    name: "MComboboxDepartment",
    props: {

    },
    data() {
        return {
            isShowDepartment: false,
        }
    }
}
</script>
<style scoped>
@import url(@/css/components/combobox.css);

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

table tr:not(:first-child):hover {
    background-color: #f0f0f0 !important;
    color: #35bf22;
    cursor: pointer;
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