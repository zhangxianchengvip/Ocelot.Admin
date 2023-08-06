<template>
    <el-dialog title="登录" :visible.sync="loginDialogFormVisible" :before-close="handleClose">
        <el-form ref="form1" :model="form" label-width="80px">
            <el-form-item label="账号">
                <el-input v-model="form.account" placeholder="请输入账号"></el-input>
            </el-form-item>
            <el-form-item label="密码">
                <el-input v-model="form.password" placeholder="请输入密码"></el-input>
            </el-form-item>
            <el-form-item>
                <div class="save">
                    <el-button @click="loginClose">取 消</el-button>
                    <el-button type="primary" @click="dialogFormVisible = false">登录</el-button>
                </div>
            </el-form-item>
        </el-form>
    </el-dialog>
</template>

<script>
export default {
    name: 'Login',
    props: { loginDialogFormVisible: { type: Boolean } },
    data() {
        return {
            form: {
                account: '',
                password: '',
            },
            formLabelWidth: '120px'
        };
    },
    methods: {
        loginClose() {
            
            this.$refs['form1'].resetFields();
            debugger
            this.$emit("loginDialogClose");
        },
        handleClose(done) {
            this.loginClose();
        }
    }
};
</script>

<style lang="scss" scoped>
.save {
    display: flex;
    justify-content: space-between;
    align-items: center;
}
</style>