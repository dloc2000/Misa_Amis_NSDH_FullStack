<template>
  <div class="navbar" style="padding-top: 12px">
    <router-link
      :to="menuItem.path"
      class="navbar__item"
      v-for="(menuItem, index) in listMenu"
      :key="menuItem.id"
      :class="{
        'item-active': activeIndex === index,
        'item-pesudo': activeIndex === index,
      }"
      @click="clickSelectedMenu(index)"
    >
      <div class="navbar__icon m-icon-24" :class="[menuItem.icon, {'item-selected': index == 1}]"></div>
      <div class="navbar__text">{{ menuItem.menu }}</div>
    </router-link>
    <!--  <div class="navbar__item item-pesudo item-active">
            <div class="navbar__icon m-icon-24 m__icon-cash item-selected"></div>
            <div class="navbar__text">Tiền mặt</div>
        </div> -->
  </div>
</template>
<script>
export default {
    name: "TheMenu",
    data() {
        return {
            listMenu: [
                {
                    id: 1,
                    menu: "Tổng quan",
                    icon: "m__icon-dashboard",
                    path: "/tong-quan",
                },
                {
                    id: 2,
                    menu: "Tiền mặt",
                    icon: "m__icon-cash",
                    path: "/employees",
                },
                {
                    id: 3,
                    menu: "Tiền gửi",
                    icon: "m__icon-deposit",
                    path: "/tien-gui",
                },
                {
                    id: 4,
                    menu: "Mua hàng",
                    icon: "m__icon-buy",
                    path: "/mua-hang",
                },
                {
                    id: 5,
                    menu: "Bán hàng",
                    icon: "m__icon-sell",
                    path: "/ban-hang",
                },
                {
                    id: 6,
                    menu: "Kho",
                    icon: "m__icon-warehouse",
                    path: "/quan-ly-hoa-don",
                },
                {
                    id: 7,
                    menu: "Quản lý hóa đơn",
                    icon: "m__icon-bill",
                    path: "/kho",
                },
                {
                    id: 8,
                    menu: "Công cụ dụng cụ",
                    icon: "m__icon-tool",
                    path: "/cong-cu",
                },
                {
                    id: 9,
                    menu: "Tài sản cố định",
                    icon: "m__icon-defaultassets",
                    path: "/tai-san-co-dinh",
                },
                {
                    id: 10,
                    menu: "Lương",
                    icon: "m__icon-salary",
                    path: "/tien-luong",
                },
                {
                    id: 11,
                    menu: "Thuế",
                    icon: "m__icon-tax",
                    path: "/thue",
                },
            ],
            activeIndex: undefined,
            routers: this.$router.options.routes,
        };
    },
    methods: {
        clickSelectedMenu(index) {
            this.activeIndex = index;
        },
    },
};
</script>
<style>
/* @import url("../../css/layout/navbar.css"); */
</style>
