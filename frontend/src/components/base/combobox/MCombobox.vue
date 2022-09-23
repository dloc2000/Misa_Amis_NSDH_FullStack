<template>
  <div
    class="combobox"
    :style="{
      width: width ? width + 'px' : '100%',
    }"
  >
    <input type="text" class="input" v-model="valueText" />
    <button @click.stop="clickShowCombobox">
      <div class="m-arrow-dropdown"></div>
    </button>
    <div class="combobox__data-above" v-if="isShow">
      <div
        class="combobox__item item-left"
        v-for="(item, index) in dataSearch"
        :key="index"
        :class="{
          'combobox__item-selected': itemSelect && itemSelect[fieldKey] == item[fieldKey],
        }"
        @click.stop="clickSelectItem(item)"
      >
        {{ item[filedName] }}
      </div>
    </div>
  </div>
</template>
<script>
export default {
  name: "MCombobox",
  props: {
    width: {
      Type: [Number, String],
      default: null,
    },
    // dữ liệu truyền vào combobox
    data: {
      Type: Array,
      default: () => [
        {
          ID: 1,
          Name: "5 bản ghi trên 1 trang",
        },
        {
          ID: 2,
          Name: "10 bản ghi trên 1 trang",
        },
        {
          ID: 3,
          Name: "15 bản ghi trên 1 trang",
        },
        {
          ID: 4,
          Name: "20 bản ghi trên 1 trang",
        },
      ],
    },
    fieldKey: {
      Type: String,
      default: "ID",
    },
    filedName: {
      Type: String,
      default: "Name",
    },
  },
  data() {
    return {
      isShow: false,
      dataSearch: this.data,
      itemSelect: {
        ID: 1,
        Name: "5 bản ghi trên 1 trang",
      },
      valueText: this.data[0].Name,
    };
  },
  methods: {
    // click ra item
    clickShowCombobox() {
      this.isShow = !this.isShow;
      this.$emit("stop-propagation");
    },
    // Chọn item combobox
    clickSelectItem(item) {
      this.itemSelect = item;
      this.valueText = item[this.filedName];
      this.isShow = false;
    },
  },
  watch: {
    // isShow(newVal, oldVal) {
    //   if (newVal != oldVal) {
    //     this.isShow = true;
    //   }
    // },
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
