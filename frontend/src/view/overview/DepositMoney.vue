<template>
  <div class="bodyy" @click="hideCombobox">
    <MCombobox :itemSelectedHide="isShow" />
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
</style>
