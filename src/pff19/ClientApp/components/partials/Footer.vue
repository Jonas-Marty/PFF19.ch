<template>
    <div class="footer">
        <div class="main-footer">
            <div class="container">
                <div class="row">

                    <div class="col-md-3 col-sm-6 links footer-block">
                        <router-link
                                v-for="route in routes" :key="route.display"
                                :to="route.path"
                                class="list-item footer-heading"
                            > {{ route.display }}</router-link>
                    </div>

                    <div class="col-md-4 col-sm-6 footer-block">
                        <!-- Begin MailChimp Signup Form -->
                        <div class="newsletter">
                            <form action="https://pff2019.us12.list-manage.com/subscribe/post?u=49efe2269ccc4a7227ef08f59&amp;id=067179a941" method="post" id="mc-embedded-subscribe-form" name="mc-embedded-subscribe-form" class="validate" target="_blank" novalidate>
                            <span class="footer-heading">KEINE NEWS VERPASSEN</span>
                            <div class="footer-content">
                                <div class="form-group">
                                    <input type="email" value="" name="EMAIL" placeholder="beispiel@mail.com" class="form-control" id="mce-EMAIL">
                                </div>
                            <div id="mce-responses" class="clear">
                                <div class="response" id="mce-error-response" style="display:none"></div>
                                <div class="response" id="mce-success-response" style="display:none"></div>
                            </div>    
                            <!-- real people should not fill this in and expect good things - do not remove this or risk form bot signups-->
                            <div style="position: absolute; left: -5000px;" aria-hidden="true"><input type="text" name="b_49efe2269ccc4a7227ef08f59_067179a941" tabindex="-1" value=""></div>
                            <div class="clear">
                                <div class="form-group ">
                                <input type="submit" value="Anmeldung Newsletter" name="subscribe"  class="btn btn-danger "></div>
                                </div>
                            </div>
                            </form>
                        </div>
                    <!--End mc_embed_signup-->
                    </div>

                    <div class="col-md-2 col-sm-6 footer-block">
                        <span class="footer-heading">FOLGE UNS</span>
                        <div class="social-media footer-content">
                            <img :src="require('assets/images/001-facebook.svg')" alt="facebook">
                            <img :src="require('assets/images/003-instagram.svg')" alt="facebook">
                        </div>
                    </div>

                    <div class="col-md-3 col-sm-6 footer-block">
                        <img class="footer-logo" :src="require('assets/images/logo_yellow_with_text.png')" alt="pff Logo"/>
                    </div>

                </div>
            </div>
        </div>
        <div class="sub-footer">
                <div class="container">
                    <div class="row">
                        <div class="col-6">
                            info@pff19.ch
                        </div>
                        <div class="col-6">
                            <router-link
                            :to="{name: 'impressum'}"
                        > Impressum</router-link>
                        </div>
                    </div>
                </div>
        </div>
    </div>
    
</template>

<script>
import { routes, helperRoutes } from '../../routes';

export default {
    data () {
        return {
            routes,
            helperRoutes
        }
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
        margin: 10px 0 20px 0;
    }

    .sub-footer {
        height: 28px;
        padding: 2px 0 2px 0;
        width: 100%;
        background: #101010;
        color: white;
    }
</style>


