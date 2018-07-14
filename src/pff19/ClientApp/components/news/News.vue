<template>
    <div class="container">
       {{ $route.params.id }} 
    </div>
</template>

<script>
import { mapGetters } from 'vuex';

export default {
    computed: {
        ...mapGetters('news',[
           'all'
       ])
    }
}
</script>

<style lang="scss" scoped>

</style>

