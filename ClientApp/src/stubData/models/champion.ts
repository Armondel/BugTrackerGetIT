class Champion {
	public id: number;

	public stringId: string;
	public name: string;
	public title: string;

	public constructor(
		id: number,
		stringId: string,
		name: string,
		title: string
	) {
		this.id = id;
		this.stringId = stringId;
		this.name = name;
		this.title = title;
	}
}

export default Champion;
