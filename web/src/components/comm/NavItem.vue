<template>
  <div class="navitem">
    <div class="left">
      <h3>Ocelot.Admin</h3>
    </div>
    <div class="right">
      <el-button type="text" size="medium" @click="onOpenLoginDialog">登录</el-button>
      <el-button type="text">注册</el-button>
    </div>
    <Login :loginDialogFormVisible="loginDialogFormVisible" @loginDialogClose="loginDialogClose"></Login>
  </div>
</template>

<script>
import Login from "../users/Login.vue";
export default {

  components: { Login },
  data() {
    return {
      loginDialogFormVisible: false
    }
  },
  methods: {
    onOpenLoginDialog() {
      this.loginDialogFormVisible = true;
    },
    loginDialogClose() {
      this.loginDialogFormVisible = false;
    }

  }

}
</script>
<style lang="scss" scoped>
.navitem {
  display: flex;
  justify-content: space-between;
  align-items: center;
}
</style>

