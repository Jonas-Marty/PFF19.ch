<template>
    <div class="sponsors container">
        <h2>{{ $t('lang.components.home.bands.registration') }}</h2>
    </div>
</template>

<script>
export default {
    data () {
        return {
            sponsors: []
        }
    },

}
</script>

<style lang="scss" scoped>
    .sponsors {
        width: 100%;
        margin-top: 20px;
    }

    .sponsor {
        margin-bottom: 20px;
    }

    .sponsors img {
        width: 100%;
    }

</style>

