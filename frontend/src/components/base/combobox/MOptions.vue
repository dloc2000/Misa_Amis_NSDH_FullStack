<template lang="">
  <div class="group__title-combobox">
        <div class="title">Sửa</div>
        <div class="combobox">
            <button class="m-icon" @click="isShow=!isShow">
                <div class="m-arrow-dropdown-blue"></div>
            </button>
            <div class="combobox__data-under" v-if="isShow">
                <div class="combobox__item" >Nhân bản</div>
                <div class="combobox__item" @click.stop="handleDelete">Xóa</div>
                <div class="combobox__item" >Ngưng sử dụng</div>
            </div>
        </div>
  </div>
</template>
<script>
export default {
    name: "MOptions",
    props: {

    },
    data() {
        return {
            isShow: false ,
        }
    },
    methods: {
        /**
         * emit hiển thị dialog xóa
         * Author: DXLOC16/09/2022
         */
        handleDelete() {
            this.$emit("delete");
            this.isShow = false;
        }
    }
};
</script>
<style scoped>
    .title {
        padding: 0px !important;
    }
</style>
