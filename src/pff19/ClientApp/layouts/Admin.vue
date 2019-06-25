<template>
  <div class="wraper">
    <nav-bar />
    <div class="container">
      <router-view></router-view>
    </div>
  </div>
</template>

<script>
import NavBar from '../components/admin/partials/Header.vue'

export default {
  components: {
    NavBar
  }
}
</script>

<style lang="scss" scoped>
.container {
  padding-top: 100px;
  padding-bottom: 50px;
}
</style>
