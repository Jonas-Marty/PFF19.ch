<template>
<div>
    <faq-de v-if="language === 'de'"></faq-de>
    <faq-fr v-if="language === 'fr'"></faq-fr>
</div>
</template>

<script> 
import { mapGetters } from 'vuex'
import faqDe from './FAQDE'
import faqFr from './FAQFR'
export default {
    components: {
        faqDe,
        faqFr
    },

    computed: {
        ...mapGetters([
            'language'
        ])
    }

}
</script>

