<template>
  <div class="lay-out-page">
    <NavItem></NavItem>
    <div class="content">
      <router-view class="layout-view"></router-view>
    </div>
  </div>
</template>

<script>
import NavItem from '@/components/comm/NavItem.vue';
export default {
  name: 'Layout',
  props: [],
  components: { NavItem },
  data() {
    
      return {

      };
  },
  watch: {

  },
  computed: {

  },
  methods: {

  },
  created() {

  },
  mounted() {

  }
};
</script>

<style lang="scss" scoped>
.lay-out-page {
.content {
  margin-top: 4px;
  width: 100%;
  height: calc(100vh - 68px);
  overflow: hidden;
  position: absolute;
  background-color: #f5f7fa;
}

.layout-view {
  height: 100%;
}
}
</style>
