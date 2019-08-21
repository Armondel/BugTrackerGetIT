/* eslint-disable @typescript-eslint/no-var-requires */

const { resolve } = require("path");
const webpack = require("webpack");
const HtmlWebpackPlugin = require("html-webpack-plugin");
const { CheckerPlugin } = require("awesome-typescript-loader");

module.exports = {
	mode: "development",
	context: resolve(__dirname, "src"),
	entry: [
		// bundle the client for webpack-dev-server
		// and connect to the provided endpoint
		"webpack-dev-server/client?http://localhost:8080",
		// bundle the client for hot reloading
		// only- means to only hot reload for successful updates
		"webpack/hot/only-dev-server",
		// the entry point of our app
		"./index.tsx"
	],
	output: {
		filename: "hotloader.js",
		// the output bundle
		path: resolve(__dirname, "dist"),
		publicPath: "/"
		// necessary for HMR to know where to load the hot update chunks
	},
	devtool: "inline-source-map",
	resolve: {
		// Add '.ts' and '.tsx' as resolvable extensions.
		extensions: [".ts", ".tsx", ".js", ".json"]
	},
	devServer: {
		port: "8080",
		// Change it if other port needs to be used
		hot: true,
		// enable HMR on the server
		noInfo: true,
		quiet: false,
		// minimize the output to terminal.
		contentBase: resolve(__dirname, "src"),
		// match the output path
		publicPath: "/"
		// match the output `publicPath`
	},
	module: {
		rules: [
			{
				enforce: "pre",
				test: /\.(ts|tsx)?$/,
				loader: "eslint-loader",
				exclude: [resolve(__dirname, "node_modules")],
				options: {
					fix: true
				}
			},
			{
				test: /\.(ts|tsx)?$/,
				use: [
					{
						loader: "awesome-typescript-loader",
						options: {
							transpileOnly: true,
							compilerOptions: {
								module: "es2015"
							}
						}
					}
				],
				exclude: [resolve(__dirname, "node_modules")]
			},
			{
				test: /\.(png|jpe?g|gif)$/,
				use: [
					{
						loader: "file-loader",
						options: {}
					}
				]
			},
			{ enforce: "pre", test: /\.js$/, loader: "source-map-loader" }
		]
	},
	plugins: [
		new CheckerPlugin(),
		new webpack.HotModuleReplacementPlugin(),
		// enable HMR globally
		new webpack.NamedModulesPlugin(),
		// prints more readable module names in the browser console on HMR updates
		new HtmlWebpackPlugin({
			template: resolve(__dirname, "src/index.html")
		})
		// inject <script> in html file.
	]
};
