<template>
  <div class="goenner col-12 col-md-4">
    <a :href="sponsor.link" target="_blank">
      <div class="goenner-text">
        {{ sponsor.name }}
      </div>
    </a>
  </div>
</template>

<script>
export default {
  // eslint-disable-next-line vue/require-prop-types
  props: ['sponsor']
}
</script>

<style lang="scss" scoped>
.sponsor {
  padding: 5px;
}
</style>
