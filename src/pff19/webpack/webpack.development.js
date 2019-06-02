module.exports = () => ({
    devtool: 'inline-source-map',
    stats: { modules: false },
    output: {
        publicPath: '/dist/'
    },
    resolve: {
        extensions: ['.js', '.vue'],
        alias: {
            vue$: 'vue/dist/vue'
        }
    },
    module: {
        rules: [
            { test: /\.css$/, use: ['style-loader', 'css-loader'] },
            { test: /\.scss$/, use: ['style-loader', 'css-loader', 'sass-loader'] }
        ]
    }
})
