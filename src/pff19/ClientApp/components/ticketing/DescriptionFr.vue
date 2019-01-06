<template>
    <div class="container">
        <div class="ticket-buying card">
            <h1 class="title">Werde mit Deinem Ticket Teil unseres Mosaiks!</h1>


            <div class="col col-md-6 offset-md-3">
                <iframe class="iframes first"
                    datasrc="https://www.ticketino.com/de/OrganizerShopEmbed/1676610/Event/Mosaik-PFF-FFS-19/80740" 
                    frameborder="0" 
                    src="https://www.ticketino.com/de/OrganizerShopEmbed/1676610/Event/Mosaik-PFF-FFS-19/80740"
                >
                </iframe>
            </div>

        </div>

        <div class="row">
            <div class="col-12 col-md-4">
            <div class="card">
                <img class="card-img-top" src="../../assets/images/3_tages_pass.jpg" alt="Card image cap">
                <div class="card-body">
                    <h5 class="card-title">3-Tagespass</h5>
                    <ul class="list-group list-group-flush">
                        <li class="list-group-item">Zutritt zum Festivalgelände und zum Zeltplatz von Freitag bis Sonntag </li>
                        <li class="list-group-item">Goodie-Bag mit Festivalbecher</li>
                        <li class="list-group-item">Shuttlebus vom Bahnhof zum Festivalgelände</li>
                        <li class="list-group-item">Essenspauschale für vier Mahlzeiten: Abendessen
                             am Freitag und Samstag, Frühstück am Samstag und Sonntag. Bitte bring Dein Essgeschirr mit.</li>
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
                        <li class="list-group-item">Festivalbecher</li>
                        <li class="list-group-item">Vergünstigte Anreise mit SBB</li>
                        <li class="list-group-item">Shuttlebus vom Bahnhof zum Festivalgelände</li>
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
                        <li class="list-group-item">1 Festivalbecher</li>
                        <li class="list-group-item">Vergünstigte Anreise mit SBB</li>
                        <li class="list-group-item">Shuttlebus vom Bahnhof zum Festivalgelände</li>
                    </ul>
                </div>
            </div>
            </div>
            
        </div>

        
        <h3>Helfer</h3>
        <p>
            Möchtest Du das PFF als Helfer unterstützen und Dir dadurch einen Rabatt 
            auf Dein Ticket sichern? Werde Helfer! (Helfer beziehen ihr vergünstigtes 
            Ticket direkt an der Kasse vor Ort.)
        </p>


        <h3>Event-Hinweise</h3>
        <ul>
            <li>Das PFF 19 ist für Besucher ab 16 Jahren. </li>
            <li>Bitte beachte, dass Glasflaschen auf dem Festivalgelände und dem Zeltplatz verboten sind.</li>
            <li>Gebrannter Alkohol ist am gesamten Festival nicht erlaubt. Er wird nicht toleriert und konfisziert.</li>
            <li>Am gesamten Festival zählen die Festivalregeln, siehe Festivalregeln im Programmheft am Check-in.</li>
        </ul>
        <p>
            Hast Du Fragen zu den Tickets, technische Probleme beim Ticketkauf oder dem Zahlungsprozess? Gerne helfen wir 
            Dir weiter unter <a href="mailto:ticket@pff19.ch">ticket@pff19.ch</a> 
        </p>


    <app-polygon color="yellow" position="left"> </app-polygon>

    </div>
    
</template>

<style lang="scss" scoped>
    .ticket-buying {
        margin-top: -250px;
        min-height: 300px;
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

    .iframes {
        margin-bottom: 50px;
        width: 100%;
        height: 500px;
    }
</style>

