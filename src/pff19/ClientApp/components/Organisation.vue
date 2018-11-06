<template>
    <div class="container">
        <h1>Organisation</h1>
        <p>
            Unser Team setzt sich aus vielen, unterschiedlichen Mosaiksteinen zusammen.
            Egal ob Zimmermann, Studentin, Informatiker oder Lehrerin – für die
            Organisation des PFF 19 bringt jeder seine individuellen Stärken ins Team ein.
            Gemeinsam gestalten wir ein unvergessliche Pfadi Folk Fest.
        </p>
        <p>
            Möchtest du etwas loswerden? Kontaktiere uns <a href="mailto:info@pff19.ch">hier</a>
        </p>
        <div class="team">
            <h2>Das Team</h2>
            <div class="row members">
                <div class="member col-6 col-md-4 col-lg-3" v-for="image in images" :key="image.scoutName">
                    <div class="card">
                        <img class="card-img-top" :src="require(`../assets/images/portraits/${image.scoutName}-min.jpg`)" :alt="image.scoutName">
                        <div class="card-body">
                            <p class="card-text"><b>{{image.scoutName}}</b>, {{image.name}}<br>{{image.ressort}}<br></p>
                            <blockquote class="blockquote mb-0">
                                <footer class="blockquote-footer">{{image.email}}</footer>
                            </blockquote>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>

export default {
    data () {
        return {
            images: [
                {
                    name: "David Bernet",
                    scoutName: 'Echo',
                    ressort: 'Co-Präsident',
                    email: 'echo@pff19.ch'
                },
                {
                    name: "Fabio Di Rocco",
                    scoutName: 'Wum',
                    ressort: 'Co-Präsident',
                    email: 'wum@pff19.ch'
                },
                {   
                    name: "Viviane Lott",
                    scoutName: 'Aviera',
                    ressort: 'Sekretariat',
                    email: 'aviera@pff19.ch'
                },
                {
                    name: "Josias Zeller",
                    scoutName: 'Fuego',
                    ressort: 'Sekretariat',
                    email: 'fuego@pff19.ch'
                },
                {
                    name: "Thomas Bauknecht",
                    scoutName: 'Snoopy',
                    ressort: 'Finanzen',
                    email: 'snoopy@pff19.ch'
                    
                },
                {
                    name: "Desirée Blass",
                    scoutName: 'Soraya',
                    ressort: 'Finanzen',
                    email: 'info@pff19.ch'
                },
                {
                    name: "Oliver Bernet",
                    scoutName: 'Pluto',
                    ressort: 'Kommunikation',
                    email: 'pluto@pff19.ch'
                },
                {
                    name: "Tobias Oechslin",
                    scoutName: 'Splash',
                    ressort: 'Sponsoring',
                    email: 'splash@pff19.ch'
                },
                {
                    name: "Larissa Meister",
                    scoutName: 'Rajko',
                    ressort: 'Programm',
                    email: 'rajko@pff19.ch'
                },
                {
                    name: "Stefan Messmer",
                    scoutName: 'Pixel',
                    ressort: 'Programm',
                    email: 'pixel@pff19.ch'
                },
                {
                    name: "Jelena Hess",
                    scoutName: 'Varuna',
                    ressort: 'Bands',
                    email: 'varuna@pff19.ch'
                },
                {
                    name: "Matthias Rothmayr",
                    scoutName: 'Piccolo',
                    ressort: 'Kommunikation',
                    email: 'piccolo@pff19.ch'
                },
                {
                    name: "Meret Tuor",
                    scoutName: 'Baghira',
                    ressort: 'Food & Beverage',
                    email: 'baghira@pff19.ch'
                },
                {
                    name: "Simon Flückiger",
                    scoutName: 'Dwalin',
                    ressort: 'Food & Beverage',
                    email: 'dwalin@pff19.ch'
                },
                {
                    name: "Flurina Mäder",
                    scoutName: 'Karibu',
                    ressort: 'Staff',
                    email: 'karibu@pff19.ch'
                },
                {
                    name: "Simone Scherberger",
                    scoutName: 'Momo',
                    ressort: 'Staff',
                    email: 'momo@pff19.ch'
                },
                {
                    name: "Davina Biella",
                    scoutName: 'Joya',
                    ressort: 'Staff',
                    email: 'joya@pff19.ch'
                },
                {
                    name: "Anna Rusch",
                    scoutName: 'Moneypenny',
                    ressort: 'Sicherheit',
                    email: 'moneypenny@pff19.ch'
                },
            ]
        }
    }

}
</script>

<style lang="scss" scoped>
    .container {
        padding-top: 100px;
        min-height: 800px;
    }

    .member {
        margin-top: 30px;
    }

    .team {
        margin-top: 50px;
    }

</style>
