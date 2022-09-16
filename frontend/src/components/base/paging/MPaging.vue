<template>
  <div class="paging__group-button">
    <button class="paging__button button-first" :disabled="isDisabled">Trước</button>
    <div class="button__number-group">
      <!-- <button class="paging__number" :class="{'button__number-selected': hasPage}">1</button>
            <button class="paging__number">2</button>
            <button class="paging__number">...</button>
            <button class="paging__number">4</button> -->
      <button
        class="paging__number"
        v-for="(page, index) in pages"
        :key="index"
        @click="clickSelectedPage(index)"
        :class="{ 'button__number-selected': activeIndex === index }"
      >
        {{ page.textNumber }}
      </button>
    </div>
    <button class="paging__button button-last">Sau</button>
  </div>
</template>
<script>
export default {
  name: "MPaging",
  props: {
    // Tổng số bản ghi
    totalRecord: {
      type: Number,
    },
    // Trang hiện tại
    currentPage: {
      type: Number,
    },
    // Số bản ghi 1 trang
    sizePage: {
      type: Number,
      default: 20,
    },
  },
  created() {},
  data() {
    return {
      // Tổng số trang
      totalPage: this.totalRecord / this.currentPage,
      activeIndex: undefined,
      hasPage: false,
      pages: [
        {
          textNumber: "1",
        },
        {
          textNumber: "2",
        },
        {
          textNumber: "...",
        },
        {
          textNumber: "4",
        },
        {
          textNumber: "5",
        },
      ],
    };
  },
  methods: {
    // setPages(page) {

    // },
    clickSelectedPage(index) {
      this.activeIndex = index;
    },
  },
};
</script>
<style></style>
