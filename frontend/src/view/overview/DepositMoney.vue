<template>
  <div class="bodyy">
   <!-- <MCheckbox v-model="employees.Checked" value="'tao la so 1'"/>
   <MCheckbox v-model="employees.Checked" value="'tao la so 2'"/>
   <MCheckbox v-model="employees.Checked" value="'tao la so 3'"/> -->
   <input type="checkbox" :value="a" v-model="employees">
   <input type="checkbox" :value="b" v-model="employees">
   <input type="checkbox" :value="c" v-model="employees">
    <br>
    <br>
    <br>
    <span>Những: {{employees}}</span>
    <br>
    <br>
    <br>
    <button @click="clickToText">CLick</button>
  </div>
</template>

<script>
import MCombobox from "@/components/base/combobox/MCombobox.vue";
import MToast from "@/components/base/toast/MToast.vue";
export default {
  components: { MCombobox, MToast },
  props: {},
  data() {
    return {
      employees: [],
      a: "co con ca",
      b: "co con lon",
      c: "co con meo"
    };
  },
  methods: {
    hideCombobox() {
      this.isShow = false;
    },
    clickToText() {
        this.text += "a"
    }
  },
};
</script>

<style scoped>
.bodyy {
  margin-top: 300px;
  margin-left: 300px;
}
@import url(@/css/main.css);
</style>
