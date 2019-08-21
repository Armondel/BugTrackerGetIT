import * as React from "react";
import { Champion } from "../../../stubData/models";
import champStyles from "./styles";
import Card from "@material-ui/core/Card";
import CardHeader from "@material-ui/core/CardHeader";
import Avatar from "@material-ui/core/Avatar";
import CardMedia from "@material-ui/core/CardMedia";
import { ImageUtils } from "../../../utils";

interface ChampionCard {
	data: Champion;
}

const ChampionCard: React.FC<ChampionCard> = props => {
	const classes = champStyles();
	const { data } = props;

	return (
		<Card>
			<CardHeader
				avatar={
					<Avatar
						src={ImageUtils.getStaticImage(data.stringId)}
						aria-label="icon"
					/>
				}
				title={data.name}
				subheader={data.title}
			/>
			<CardMedia
				className={classes.media}
				image={ImageUtils.getSplashImage(data.stringId)}
				title={`${data.name} Logo`}
			/>
		</Card>
	);
};

export default ChampionCard;
