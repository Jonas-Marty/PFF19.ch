<template>
    <div class="footer">
        <div class="main-footer">
            <div class="container">
                <div class="row">

                    <div class="col-md-3 col-sm-6 links footer-block">
                        <span   
                            class="list-item"                              
                            v-for="route in getDefaultRoutes" :key="route.name"
                        >
                        <router-link
                                v-if="route.important"
                                :to="route.path"
                                class="footer-heading"
                            > {{ $t(`lang.navigation.${route.name}`) }}</router-link>
                        </span>
                    </div>

                    <div class="col-md-4 col-sm-6 footer-block">
                        <!-- Begin MailChimp Signup Form -->
                        <div class="newsletter">
                            <form action="https://pff2019.us12.list-manage.com/subscribe/post?u=49efe2269ccc4a7227ef08f59&amp;id=067179a941" method="post" id="mc-embedded-subscribe-form" name="mc-embedded-subscribe-form" class="validate" target="_blank" novalidate>
                            <span class="footer-heading">{{ $t('lang.components.footer.dont_miss_news') | uppercase}}</span>
                            <div class="footer-content">
                                <div class="form-group">
                                    <input type="email" value="" name="EMAIL" :placeholder="$t('lang.components.footer.example') + '@mail.com'" class="form-control" id="mce-EMAIL">
                                </div>
                            <div id="mce-responses" class="clear">
                                <div class="response" id="mce-error-response" style="display:none"></div>
                                <div class="response" id="mce-success-response" style="display:none"></div>
                            </div>    
                            <!-- real people should not fill this in and expect good things - do not remove this or risk form bot signups-->
                            <div style="position: absolute; left: -5000px;" aria-hidden="true"><input type="text" name="b_49efe2269ccc4a7227ef08f59_067179a941" tabindex="-1" value=""></div>
                            <div class="clear">
                                <div class="form-group ">
                                <input type="submit" :value="$t('lang.components.footer.register_newsletter') | uppercase" name="subscribe"  class="btn btn-danger "></div>
                                </div>
                            </div>
                            </form>
                        </div>
                    <!--End mc_embed_signup-->
                    </div>

                    <div class="col-md-2 col-sm-6 footer-block">
                        <span class="footer-heading">{{ $t('lang.components.footer.follow_us') | uppercase }}</span>
                        <div class="social-media footer-content">
                            <a href="https://www.facebook.com/pff19mosaik/" target="_blank"> <img :src="require('assets/images/facebook.png')" alt="facebook"> </a>
                            <a href="https://www.instagram.com/pff_19_mosaik/" target="_blank"> <img :src="require('assets/images/instagram.png')" alt="instagram"> </a>
                            <a href="https://open.spotify.com/user/k0y6g4in0wgw2v14gt3by8yl8/playlist/6OuHBOtWl8BIA7DCtQHIeL?" target="_blank"> <img :src="require('assets/images/spotify.png')" alt="spotify"> </a>
                        </div>
                    </div>

                    <div class="col-10 col-md-3 col-sm-6 footer-block">
                        <img class="footer-logo" :src="require('assets/images/logo_yellow_with_text.png')" alt="pff Logo"/>
                    </div>

                </div>

            </div>
        </div>
        <div class="second-footer">
               <div class="container">
                    <div class="row">
                        <app-sponsors></app-sponsors>
                    </div>

                    <div class="movement-suisse">
                        <h4>{{ $t('lang.components.footer.pbs') }}</h4>
                        <div class="row">
                            <div class="offset-1 col-10 col-md-4">
                                <a href="https://www.scout.ch/de" target="_blank">
                                    <img class="pbs-logo" :src="require('assets/images/logo_pbs.png')" alt="PBS Logo"/>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        <div class="sub-footer">
                <div class="container">
                    <div class="row">
                        <div class="col-6">
                            <a href="mailto:info@pff19.ch">info@pff19.ch</a>
                        </div>
                        <div class="col-6">
                            <router-link
                            class="float-right"
                            :to="{name: 'impressum'}"
                        > {{ $t('lang.navigation.impressum') }}</router-link>
                        </div>
                    </div>
                </div>
        </div>
    </div>
    
</template>

<script>
import { routes } from '../../routes'
import Sponsor from './sponsors/SponsorList'

export default {
    data () {
        return {
            routes
        }
    },

    computed: {
        getDefaultRoutes(){
            return this.routes.find(route => route.name === 'default').children
        }
    },

    components: {
        'app-sponsors': Sponsor
    }

}
</script>

<style scoped>
    .footer {
        margin-top: 30px;
    }

    .main-footer {
        width: 100%;
        padding: 40px 0 10px 0;
        background: #202020;
        color: white;
        border: 1px solid #202020;
    }

    .main-footer a, .sub-footer a {
        color: white;
    }

    .list-item {
        display: block;
        margin-bottom: 10px;
    }

    .social-media img{
        width: 30px;
        margin-right:10px;
        margin-bottom: 10px;
    }

    .footer-heading {
        font-family: "Glacial Indifference Bold";
        text-transform: uppercase;
    }
    
    .footer-content {
        margin-top: 20px;
    }

    .footer-logo {
        width: 100%
    }

    .newsletter {
        max-width: 300px;
    }

    .footer-block {
        margin: auto;
        margin-top: 20px;
        margin-bottom: 20px;
    }

    .sub-footer {
        height: 28px;
        padding: 2px 0 2px 0;
        width: 100%;
        background: #101010;
        color: white;
    }

    .pbs-logo {
        width: 100%
    }

    .second-footer {
        background: #2b2b2b;
        color: white;
    }

    .movement-suisse {
        margin-top: 40px;
    }
</style>


