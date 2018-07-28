const path = require('path');
const webpack = require('webpack');
const ExtractTextPlugin = require('extract-text-webpack-plugin');
const bundleOutputDir = './wwwroot/dist';

module.exports = env => {
    console.log(process.env.NODE_ENV);
    const isDevBuild = env === 'dev' || 'development' ? true : false;
    return [{
        stats: { modules: false },
        entry: { 'main': './ClientApp/boot-app.js' },
        resolve: {
            extensions: ['.js', '.vue'],
            alias: {
                'vue$': 'vue/dist/vue',
                'components': path.resolve(__dirname, './ClientApp/components'),
                'views': path.resolve(__dirname, './ClientApp/views'),
                'utils': path.resolve(__dirname, './ClientApp/utils'),
                'api': path.resolve(__dirname, './ClientApp/store/api'),
                'assets': path.resolve(__dirname, './ClientApp/assets')
            }
        },
        output: {
            path: path.join(__dirname, bundleOutputDir),
            filename: '[name].js',
            publicPath: '/dist/'
        },
        module: {
            rules: [
                { test: /\.vue$/, include: /ClientApp/, use: 'vue-loader' },
                { test: /\.js$/, include: /ClientApp/, use: 'babel-loader' },
                { test: /\.scss$/, use: isDevBuild ? ['style-loader', 'css-loader', 'sass-loader']: ExtractTextPlugin.extract({ 
                        use: ['css-loader', 'sass-loader'] 
                    }) 
                },
                { test: /\.(png|jpg|jpeg|gif|svg)$/, use: 'url-loader?limit=25000' },
                {
                    test: /\.(woff(2)?|ttf|eot)(\?v=\d+\.\d+\.\d+)?$/,
                    use: [{
                        loader: 'file-loader',
                        options: {
                            name: '[name].[ext]',
                            outputPath: 'fonts/',
                        }
                    }]
                }
            ]
        },
        plugins: [
            new webpack.DllReferencePlugin({
                context: __dirname,
                manifest: require('./wwwroot/dist/vendor-manifest.json')
            })
        ].concat(isDevBuild ? [
            // Plugins that apply in development builds only
            new webpack.SourceMapDevToolPlugin({
                filename: '[file].map', // Remove this line if you prefer inline source maps
                moduleFilenameTemplate: path.relative(bundleOutputDir, '[resourcePath]') // Point sourcemap entries to the original file locations on disk
            })
        ] : [
                // Plugins that apply in production builds only
                new webpack.optimize.UglifyJsPlugin(),
                new ExtractTextPlugin('site.scss')
            ])
    }];
};
