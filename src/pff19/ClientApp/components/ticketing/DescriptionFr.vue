<template>
    <div class="container">
        <div class="ticket-buying card row">
            <h1 class="title">Werde mit Deinem Ticket Teil unseres Mosaiks!</h1>

            <div class="alert alert-info helfer">
                <h3>Helfer</h3>
                <p>
                    Möchtest Du das PFF als Helfer unterstützen und Dir dadurch einen Rabatt 
                    auf Dein Ticket sichern? <router-link :to="{name: 'helper'}"> Werde Helfer!</router-link> (Helfer beziehen ihr vergünstigtes 
                    Ticket direkt an der Kasse vor Ort.)
                </p>
            </div>

            <div class="col-md-6 offset-md-3 iframe-wrapper">
                <iframe  
                    class="iframe"
                    datasrc="https://www.ticketino.com/de/Event/Embed/80740"
                    frameborder="0" 
                    src="https://www.ticketino.com/de/Event/Embed/80740">
                 </iframe>
            </div>

        </div>

        <div class="alert">
        
        <h3>Infos</h3>
        <ul>
            <li>Beim Kauf eines 3-Tagespasses bis zum <b>31. Mai 2019</b> erhält man <b>50% 
                Vergünstigung</b> auf das Ticket für die Hin- und Rückfahrt (SBB Rabatt Code).
            </li>

            <li><b>Early-bird</b> 300x 3-Tagespass zum Preis von CHF 139.-</li>

            <li>
                <b>Familienticket</b> enthält Eintritt für 1 Familie (2 Erwachsene + ihre Kinder bis 16 Jahre). Andere Tickets
                Für den Sonntag können nicht im Vorverkauf gekauft werden. Kinder unter 6 Jahre sind <b>gratis</b>.
            </li>

            <li> <b>Vor Ort</b> können am Sonntag Einzeltickets wie folgt gekauft werden: Erwachsene 
                (über 16 Jahre: CHF 15.-), Kinder zwischen 6 und 16 Jahre CHF 5.-
            </li>

            <li>Das PFF 19 ist für Besucher ab 16 Jahren. </li>

            <li>Bitte beachte, dass Glasflaschen auf dem Festivalgelände und dem Zeltplatz verboten sind.</li>

            <li>Gebrannter Alkohol ist am gesamten Festival nicht erlaubt. Er wird nicht toleriert und konfisziert.</li>

            <li>Am gesamten Festival zählen die Festivalregeln, siehe Festivalregeln im Programmheft am Check-in.</li>

        </ul>
        <p>
            Noch Fragen zu den Tickets oder zum Festival? Die Antwort findest du bestimmt <router-link :to="{name: 'faq'}"> hier</router-link>
        </p>
        <p>
            Hast du technische Probleme beim Ticketkauf oder dem Zahlungsprozess? Gerne helfen wir 
            Dir weiter unter <a href="mailto:ticket@pff19.ch">ticket@pff19.ch</a> 
        </p>
        </div>

        <div class="row">
            <div class="col-12 col-md-4">
            <div class="card">
                <img class="card-img-top" src="../../assets/images/3_tages_pass.jpg" alt="Card image cap">
                <div class="card-body">
                    <h5 class="card-title">3-Tagespass</h5>
                    <ul class="list-group list-group-flush">
                        <li class="list-group-item">Zutritt zum Festivalgelände und zum Zeltplatz von Freitag bis Sonntag </li>
                        <li class="list-group-item">Goodie-Bag inkl. 1xFestivalbecher</li>
                        <li class="list-group-item">Verpflegung: 2x Abend, 2x Morgen. Bitte bring Dein Essgeschirr mit.</li>
                        <li class="list-group-item">Shuttlebus vom Bahnhof Stäfa zum Festivalgelände</li>
                        <li class="list-group-item">Vergünstigte Anreise mit SBB*</li>

                    </ul>
                </div>
            </div>
            </div>

            <div class="col-12 col-md-4">          
            <div class="card">
                <img class="card-img-top" src="../../assets/images/1_tagesticket.jpg" alt="Card image cap">
                <div class="card-body">
                    <h5 class="card-title">Tageseintritt Freitag oder Samstag</h5>
                    <ul class="list-group list-group-flush">
                        <li class="list-group-item">Zutritt zum Festivalgelände am jeweiligen Tag</li>
                        <li class="list-group-item">1xFestivalbecher</li>
                        <li class="list-group-item">Verpflegung: 1x Abend. Bitte bring Dein Essgeschirr mit.</li>
                        <li class="list-group-item">Shuttlebus vom Bahnhof Stäfa zum Festivalgelände</li>
                    </ul>
                </div>
            </div>
            </div>

            <div class="col-12 col-md-4">
            <div class="card">
                <img class="card-img-top" src="../../assets/images/kinder_sonntag.jpg" alt="Card image cap">
                <div class="card-body">
                    <h5 class="card-title">Familienticket Sonntag</h5>
                    <ul class="list-group list-group-flush">
                        <li class="list-group-item">Zutritt zum Festivalgelände am Sonntag für die Familie (2 Erwachsene + Kinder)</li>
                        <li class="list-group-item">1x Festivalbecher</li>
                        <li class="list-group-item">Shuttlebus vom Bahnhof Stäfa zum Festivalgelände</li>
                    </ul>
                </div>
            </div>
            </div>
            
        </div>


        <app-polygon color="yellow" position="left"> </app-polygon>

    </div>
    
</template>

<style lang="scss" scoped>
    .ticket-buying {
        margin-top: -250px;
        min-height: 800px;
        z-index: 2;
        position: relative;
    }

    .card {
        margin-bottom: 30px;
    }

    .title {
        width: 80%;
        margin: auto;
        margin-bottom: 50px;
        margin-top: 50px;
    }
    .card-img-top{
        padding: 0;
    }

    .iframe-wrapper {
        margin-bottom: 30px;
    }

    .iframe {
        width: 100%;
        height: 400px;
    }

    .helfer {
        width: 80%;
        margin: 0 auto;
        margin-bottom: 50px;
    }

</style>

