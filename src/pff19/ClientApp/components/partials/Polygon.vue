<template>
  <div :class="position" class="polygon">
    <picture>
      <source
        :srcset="require(`../../assets/images/polygon_${color}.svg`)"
        media="(min-width: 1199px)"
      />
      <img
        src="data:image/gif;base64,R0lGODlhAQABAIAAAP///wAAACH5BAEAAAAALAAAAAABAAEAAAICRAEAOw=="
      />
    </picture>
  </div>
</template>
<script>
export default {
  // eslint-disable-next-line vue/require-prop-types
  props: ['color', 'position']
}
</script>

<style lang="scss" scoped>
.polygon picture {
  position: absolute;
  bottom: 10%;
  right: 0;
  width: 30%;
}
</style>
