<template>
  <div class="content">
    <!-- <EmployeeList /> -->
    <router-view></router-view>
  </div>
</template>

<script>
// import EmployeeList from "@/view/employees/EmployeeList.vue";
export default {
  components: {},
  methods: {
    btnOnClickForm() {
      this.isShowDialog = true;
    },
  },
  data() {
    return {
      isShowDialog: false,
    };
  },
};
</script>

<style>
/* @import url("../../css/layout/content.css"); */
</style>
