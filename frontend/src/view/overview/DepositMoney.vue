<template>
  <div>
    <MToast />
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
