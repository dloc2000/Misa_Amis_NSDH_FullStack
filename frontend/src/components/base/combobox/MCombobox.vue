<template>
  <div class="combobox">
    <button class="m-icon" @click="clickShowCombobox">
      <div class="m-arrow-dropdown-blue"></div>
    </button>
    <div class="combobox__data-under" v-show="isShow">
      <div class="combobox__item" value="0">Nhân bản</div>
      <div class="combobox__item" value="1">Xóa</div>
      <div class="combobox__item" value="2">Ngưng sử dụng</div>
    </div>
  </div>
</template>
<script>
export default {
  name: "MCombobox",
  data() {
    return {
      isShow: false,
    };
  },
  methods: {
    clickShowCombobox() {
      this.isShow = !this.isShow;
    },
  },
};
</script>

<style>
.combobox {
  position: relative;
  height: 32px;
  width: 200px;
  min-width: 50px;
  box-sizing: border-box;
  display: flex;
}
.combobox__item {
  height: 40px;
  display: flex;
  align-items: center;
  padding-left: 6px;
  /* padding-left: 56px; */
}

.combobox__data-above {
  position: absolute;
  top: -530%;
  width: 100%;
  border: solid 1px #ccc;
  z-index: 1;
  background-color: #fff;
  max-height: 200px;
  overflow-y: auto;
  transition: all 0.5s ease 0.5s;
}

.combobox__data-under {
  position: absolute;
  top: 100%;
  width: 100%;
  border: solid 1px #ccc;
  z-index: 99 !important;
  background-color: #fff;
  max-height: 200px;
}
.m-arrow-dropdown {
  background-image: url(../../../assets/img/Sprites.64af8f61.svg);
  background-repeat: no-repeat;
  background-position: -564px -365px;
  width: 8px;
  height: 5px;
}

.m-arrow-dropdown-blue {
  background-image: url(../../../assets/img/Sprites.64af8f61.svg);
  background-repeat: no-repeat;
  background-position: -900px -365px;
  width: 8px;
  height: 6px;
}
</style>
