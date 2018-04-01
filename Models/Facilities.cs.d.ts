declare module server {
	interface facility {
		id: any;
		facilityId: number;
		facilityName: string;
		location: {
			id: any;
			postCode: string;
			street: string;
			streetNo: string;
			suburb: string;
			coordinates: {
				id: any;
				latitude: number;
				longtitude: number;
			};
		};
		website: string;
		email: string;
		medicalProfessionals: any[];
		facilitySupport: any[];
	}
	interface address {
		id: any;
		postCode: string;
		street: string;
		streetNo: string;
		suburb: string;
		coordinates: {
			id: any;
			latitude: number;
			longtitude: number;
		};
	}
	interface decimalDegrees {
		id: any;
		latitude: number;
		longtitude: number;
	}
	interface facilitySupport {
		id: any;
		supportName: string;
		supportDescription: string;
	}
}
