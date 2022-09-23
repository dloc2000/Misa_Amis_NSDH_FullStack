<template lang="">
  <div class="group__title-combobox">
        <div class="title">Sửa</div>
        <div class="combobox">
            <button class="m-icon">
                <div class="m-arrow-dropdown-blue"></div>
            </button>
            <div class="combobox__data-under" hidden>
                <div class="combobox__item" value="0">Nhân bản</div>
                <div class="combobox__item" value="1" id="btnDelEmp">Xóa</div>
                <div class="combobox__item" value="2">Ngưng sử dụng</div>
            </div>
        </div>
  </div>
</template>
<script>
export default {
    name: "MOptions",
};
</script>
<style scoped>
    .title {
        padding: 0px !important;
    }
</style>
