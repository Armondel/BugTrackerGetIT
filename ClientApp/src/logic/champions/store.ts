import { Champion } from "../../stubData/models";
import { action, autorun, observable } from "mobx";
import { DataUtils } from "../../utils";

class ObservableChampionStore {
	@observable public champions: Champion[] = [];
	@observable public filterString: string = "";

	public constructor() {
		autorun(() => console.log("Store initialized"));
	}

	@action
	public loadChamps = (): void => {
		autorun(() => console.log("Start loading champs"));
		const jsonChampData = DataUtils.getChampionsData();
		setTimeout(() => {
			this.champions = Object.keys(jsonChampData.data).map(key => {
				const champData = jsonChampData.data[key];
				return new Champion(
					parseInt(champData.key),
					champData.id,
					champData.name,
					champData.title
				);
			});
		}, 2000);
		autorun(() => console.log("Champs loaded"));
	};
}

export default new ObservableChampionStore();
