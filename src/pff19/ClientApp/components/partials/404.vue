<template>
  <div class="container">
    <div class="row justify-content-center">
      <img src="../../assets/images/404.png" class=".img-fluid. error-image" />
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      image: require('../../assets/images/404.png')
    }
  }
}
</script>

<style scoped>
.container {
  padding-top: 100px;
  min-height: 750px;
}

.error-image {
  margin-top: 100px;
  max-width: 100%;
  height: auto;
}
</style>
