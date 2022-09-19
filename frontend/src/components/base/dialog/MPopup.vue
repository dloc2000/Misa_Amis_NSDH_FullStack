<template>
  <div class="popup">
    <div class="popup__box">
      <div class="test">
        <div class="pop__up-body">
          <div class="pop__up-icon m__icon-warning-circle"></div>
          <div class="pop__up-content" style="margin-left: 30px">
            Mã nhân viên ko đc để trống
          </div>
        </div>
        <div class="divides"></div>
      </div>
      <div class="popup__footer">
        <MButton />
      </div>
    </div>
  </div>
</template>
<script>
import MButton from "../button/MButton.vue";
export default { components: { MButton } };
</script>
<style>
@import url("@/css/components/dialog.css");

.popup {
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background-color: rgba(0, 0, 0, 0.16);
  z-index: 1000;
}
.popup__box {
  display: flex;
  position: absolute;
  flex-direction: column;
  justify-content: space-between;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  border-radius: 4px;
  box-sizing: border-box;
  background-color: #fff;
  width: 444px;
  min-width: 400px;
  height: 184px;
  padding: 32px;
}

.test {
  position: relative;
  padding-top: 10px;
}
.pop__up-body {
  display: flex;
  align-items: center;
  justify-content: start;
}
.popup .divides {
  position: absolute;
  height: 1px;
  width: 100%;
  background-color: #b8bcc3;
  bottom: -50%;
}
.popup__footer {
  display: flex;
  align-items: center;
  justify-content: center;
}
</style>
