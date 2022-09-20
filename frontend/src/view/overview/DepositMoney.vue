<template>
  <div class="bodyy" @click="hideCombobox">
    <div class="form__popup-close">
      <div class="btn-help m__icon-help"></div>
      <div class="btn-close m__icon-close" @click="clickConfirmHideForm"></div>
    </div>
  </div>
</template>

<script>
import MCombobox from "@/components/base/combobox/MCombobox.vue";
export default {
  components: { MCombobox },
  props: {},
  data() {
    return {
      isShow: true,
    };
  },
  methods: {
    hideCombobox() {
      this.isShow = false;
    },
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
