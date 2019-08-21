import * as React from "react";
import { observer } from "mobx-react";
import { ChampionStore } from "../../../logic/champions";
import ChampionCard from "../ChampionCard";
import Grid from "@material-ui/core/Grid";
import champGridStyles from "./styles";

const ChampionGrid: React.FC = () => {
	React.useEffect(() => {
		ChampionStore.loadChamps();
	}, []);

	const classes = champGridStyles();

	return (
		<Grid container spacing={2} className={classes.root}>
			{ChampionStore.champions.map(champion => (
				<Grid item xs={3} key={champion.id}>
					<ChampionCard data={champion} />
				</Grid>
			))}
		</Grid>
	);
};

export default observer(ChampionGrid);
