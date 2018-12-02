<template>
    <div class="polygon" :class="position">
        <picture>
            <source media="(min-width: 1199px)" :srcset="require(`../../assets/images/polygon_${color}.svg`)">
            <img src="data:image/gif;base64,R0lGODlhAQABAIAAAP///wAAACH5BAEAAAAALAAAAAABAAEAAAICRAEAOw==" />
        </picture>
    </div>
</template>
<script>
export default {
    props: ['color', 'position'],
}
</script>

<style lang="scss" scoped>
    .polygon picture{
        position: absolute;
        bottom: 10%;
        right: 0;
        width: 30%;
    }
</style>

