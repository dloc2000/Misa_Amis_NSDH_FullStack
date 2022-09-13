<template>
  <div class="loader">
    <div class="loader-content"></div>
  </div>
</template>

<script>
export default {
  name: "MLoading",
};
</script>

<style scoped>
.loader {
  overflow: hidden;
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background-color: rgba(0, 0, 0, 0.16);
  z-index: 99992;
}

.loader-content {
  height: 100px;
  width: 100px;
  position: absolute;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  border: 16px solid #45474b;
  border-top-color: #019160;
  margin: auto;
  border-radius: 50%;
  animation: spin 1s infinite linear;
}

.loader-content2 {
  position: absolute;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  font-size: 0;
  height: 60px;
  width: 60px;
  margin: auto;
  background-color: transparent;
  border: 4px solid #fff;
  border-radius: 50%;
  border-top-color: transparent;
  animation: spin2 1s 0.4s infinite linear;
}

@keyframes spin {
  100% {
    transform: rotate(360deg);
  }
}

@keyframes spin2 {
  100% {
    transform: rotate(360deg);
  }
}
</style>
