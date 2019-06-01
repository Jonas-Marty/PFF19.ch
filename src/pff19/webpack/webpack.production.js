const MiniCssExtractPlugin = require('mini-css-extract-plugin')
const TerserPlugin = require('terser-webpack-plugin');

module.exports = () => ({
    mode: 'production',
    devtool: 'source-map',
    stats: { modules: false },
    entry: { main: './ClientApp/boot-app.js' },
    optimization: {
        minimizer: [new TerserPlugin()],
        splitChunks: {
            chunks: 'all'
        }
    },

    module: {
        rules: [
            { test: /\.css$/, use: [MiniCssExtractPlugin.loader, 'css-loader'] },
            { test: /\.scss$/, use: [MiniCssExtractPlugin.loader, 'css-loader', 'sass-loader'] }
        ]
    },
    plugins: [
        new MiniCssExtractPlugin({
            filename: '[name].css'
        })
    ]
})
