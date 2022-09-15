<template>
  <div>
    <div>Tổng quan</div>
    <MLoading v-if="isLoading"/>
  </div>
</template>

<script>
import MLoading from '@/components/base/loading/MLoading.vue';
export default {
    created() {
        setTimeout(() => {
            this.isLoading = false;
        }, 1000);
    },
    data() {
        return {
          isLoading: true
        }
    },
    components: { MLoading }
};
</script>

<style></style>
