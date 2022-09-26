<template>
  <div class="paging__group-button">
    <button class="paging__button button-first" :disabled="isDisabled" @click="prevPage">Trước</button>
    <div class="button__number-group">
        <button
          class="paging__number"
          v-for="(page, index) in pages"
          :key="index"
          @click="clickSelectedPage(page.id)"
          :class="{ 'button__number-selected': activeIndex === page.id }"
        >
          {{ page.pageNumber }}
        </button>
        <button class="paging__number">...</button>
        <button class="paging__number" :class="{'button__number-selected': activeIndex === dataPaging.TotalPage}" @click="clickSelectedPage(dataPaging.TotalPage)">{{dataPaging.TotalPage}}</button>
    </div>
    <button class="paging__button button-last" @click="nextPage" :disabled="isDisabledNext">Sau</button>
  </div>
</template>
<script>
export default {
  name: "MPaging",
  props: {
    // Tổng số bản ghi
    totalRecord: {
      type: Number,
      default: 100
    },
    dataPaging: {
      type: Object,
      default:{}
    }
  },
  created() {
    this.clickSelectedPage();
  },
  data() {
    return {
      // Tổng số trang
      totalPage: this.dataPaging.TotalPage,
      activeIndex: undefined,
      hasPage: false,
      isDisabled: true,
      isDisabledNext: false,
       // Số bản ghi 1 trang
      pageSize: {
        type: Number,
        default: 20,
      },
       // Trang hiện tại
     pageNumber: {
        type: Number,
        default: 1
     },
      pages: [
        {
          id: 1,
          pageNumber: 1,
        },
        {
          id: 2,
          pageNumber: 2,
        },
        {
          id: 3,
          pageNumber: 3,
        },
        {
          id: 4,
          pageNumber: 4,
        },
        {
          id: 5,
          pageNumber: 5,
        },
      ],
    };
  },
  methods: {
   
    /**
     * Quay lại trang liền trước
     * Author: DXLOC 23/09/2022
     */
    prevPage() {
        var page = this.dataPaging.CurrentPage - 1 
        this.clickSelectedPage(page)
        if(page > 5) {
            this.pages.push({
              id: page,
              pageNumber: page
            })
        }
    },
    /**
     * Trang tiếp theo liền sau
     * Author: DXLOC 23/09/2022
     */
    nextPage() {
        var page = this.dataPaging.CurrentPage + 1 
        if(page > 5) {
            this.pages.push({
              id: page,
              pageNumber: page
            })
        }
        this.clickSelectedPage(page)
    },
    /**
     * Click chọn trang
     * Author: DXLOC 23/09/2022
     */
    clickSelectedPage(id) {
      this.activeIndex = id;
      if(id < 6) {
       this.pages = this.pages.filter((x) => x.id < 6)
      }
      if(id == this.dataPaging.CurrentPage ) {
        this.isDisabledNext = true
      } else {
        this.isDisabledNext = false;
      }
      if(id != 1) {
        this.isDisabled = false
      } else {
        this.isDisabled = true;
      }
      // this.pageNumber =pages[id-1].pageNumber
      this.$emit("on-paging", id);
    },
  },
};
</script>
<style></style>
