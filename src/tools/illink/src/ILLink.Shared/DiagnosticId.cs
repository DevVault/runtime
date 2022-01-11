﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace ILLink.Shared
{
	public enum DiagnosticId
	{
		// Linker error ids.
		XmlFeatureDoesNotSpecifyFeatureValue = 1001,
		XmlUnsupportedNonBooleanValueForFeature = 1002,
		XmlException = 1003,
		CouldNotFindMethodInAssembly = 1005,
		CannotStubConstructorWhenBaseTypeDoesNotHaveConstructor = 1006,
		CouldNotFindType = 1007,
		CouldNotFindConstructor = 1008,
		CouldNotFindAssemblyReference = 1009,
		CouldNotLoadAssembly = 1010,
		FailedToWriteOutput = 1011,
		LinkerUnexpectedError = 1012,
		ErrorProcessingXmlLocation = 1013,
		XmlDocumentLocationHasInvalidFeatureDefault = 1014,
		UnrecognizedCommandLineOption = 1015,
		InvalidWarningVersion = 1016,
		InvalidGenerateWarningSuppressionsValue = 1017,
		MissingArgumentForCommanLineOptionName = 1018,
		CustomDataFormatIsInvalid = 1019,
		NoFilesToLinkSpecified = 1020,
		NewMvidAndDeterministicCannotBeUsedAtSameTime = 1021,
		AssemblyInCustomStepOptionCouldNotBeFound = 1022,
		AssemblyPathInCustomStepMustBeFullyQualified = 1023,
		InvalidArgForCustomStep = 1024,
		ExpectedSignToControlNewStepInsertion = 1025,
		PipelineStepCouldNotBeFound = 1026,
		CustomStepTypeCouldNotBeFound = 1027,
		CustomStepTypeIsIncompatibleWithLinkerVersion = 1028,
		InvalidOptimizationValue = 1029,
		InvalidArgumentForTokenOption = 1030,
		InvalidAssemblyAction = 1031,
		RootAssemblyCouldNotBeFound = 1032,
		XmlDescriptorCouldNotBeFound = 1033,
		RootAssemblyDoesNotHaveEntryPoint = 1034,
		RootAssemblyCannotUseAction = 1035,
		InvalidAssemblyName = 1036,
		InvalidAssemblyRootMode = 1037,
		ExportedTypeCannotBeResolved = 1038,
		ReferenceAssemblyCouldNotBeLoaded = 1039,
		FailedToResolveMetadataElement = 1040,
		TypeUsedWithAttributeValueCouldNotBeFound = 1041,
		CannotConverValueToType = 1042,
		CustomAttributeArgumentForTypeRequiresNestedNode = 1043,
		CouldNotResolveCustomAttributeTypeValue = 1044,
		UnexpectedAttributeArgumentType = 1045,
		InvalidMetadataOption = 1046,

		// Linker diagnostic ids.
		TypeHasNoFieldsToPreserve = 2001,
		TypeHasNoMethodsToPreserve = 2002,
		CouldNotResolveDependencyAssembly = 2003,
		CouldNotResolveDependencyType = 2004,
		CouldNotResolveDependencyMember = 2005,
		XmlCouldNotResolveAssembly = 2007,
		XmlCouldNotResolveType = 2008,
		XmlCouldNotFindMethodOnType = 2009,
		XmlInvalidValueForStub = 2010,
		XmlUnkownBodyModification = 2011,
		XmlCouldNotFindFieldOnType = 2012,
		XmlSubstitutedFieldNeedsToBeStatic = 2013,
		XmlMissingSubstitutionValueForField = 2014,
		XmlInvalidSubstitutionValueForField = 2015,
		XmlCouldNotFindEventOnType = 2016,
		XmlCouldNotFindPropertyOnType = 2017,
		XmlCouldNotFindGetAccesorOfPropertyOnType = 2018,
		XmlCouldNotFindSetAccesorOfPropertyOnType = 2019,
		XmlCouldNotFindMatchingConstructorForCustomAttribute = 2022,
		XmlMoreThanOneReturnElementForMethod = 2023,
		XmlMoreThanOneValyForParameterOfMethod = 2024,
		XmlDuplicatePreserveMember = 2025,
		RequiresUnreferencedCode = 2026,
		AttributeShouldOnlyBeUsedOnceOnMember = 2027,
		AttributeDoesntHaveTheRequiredNumberOfParameters = 2028,
		XmlElementDoesNotContainRequiredAttributeFullname = 2029,
		XmlCouldNotResolveAssemblyForAttribute = 2030,
		XmlAttributeTypeCouldNotBeFound = 2031,
		UnrecognizedParameterInMethodCreateInstance = 2032,
		DeprecatedPreserveDependencyAttribute = 2033,
		DynamicDependencyAttributeCouldNotBeAnalyzed = 2034,
		UnresolvedAssemblyInDynamicDependencyAttribute = 2035,
		UnresolvedTypeInDynamicDependencyAttribute = 2036,
		NoMembersResolvedForMemberSignatureOrType = 2037,
		XmlMissingNameAttributeInResource = 2038,
		XmlInvalidValueForAttributeActionForResource = 2039,
		XmlCouldNotFindResourceToRemoveInAssembly = 2040,
		DynamicallyAccessedMembersIsNotAllowedOnMethods = 2041,
		DynamicallyAccessedMembersCouldNotFindBackingField = 2042,
		DynamicallyAccessedMembersConflictsBetweenPropertyAndAccessor = 2043,
		XmlCouldNotFindAnyTypeInNamespace = 2044,
		AttributeIsReferencedButTrimmerRemoveAllInstances = 2045,
		RequiresUnreferencedCodeAttributeMismatch = 2046,
		XmlRemoveAttributeInstancesCanOnlyBeUsedOnType = 2048,
		CorrectnessOfCOMCannotBeGuaranteed = 2050,
		MakeGenericType = 2055,
		MakeGenericMethod = 2060,
		PropertyAccessorParameterInLinqExpressionsCannotBeStaticallyDetermined = 2103,
		RequiresOnBaseClass = 2109,
		RequiresUnreferencedCodeOnStaticConstructor = 2116,

		// Single-file diagnostic ids.
		AvoidAssemblyLocationInSingleFile = 3000,
		AvoidAssemblyGetFilesInSingleFile = 3001,
		RequiresAssemblyFiles = 3002,
		RequiresAssemblyFilesAttributeMismatch = 3003,

		// Dynamic code diagnostic ids.
		RequiresDynamicCode = 3050,
		RequiresDynamicCodeAttributeMismatch = 3051
	}

	public static class DiagnosticIdExtensions
	{
		public static string AsString (this DiagnosticId diagnosticId) => $"IL{(int) diagnosticId}";

		public static string GetDiagnosticSubcategory (this DiagnosticId diagnosticId) =>
			(int) diagnosticId switch {
				2026 => MessageSubCategory.TrimAnalysis,
				2032 => MessageSubCategory.TrimAnalysis,
				2041 => MessageSubCategory.TrimAnalysis,
				2042 => MessageSubCategory.TrimAnalysis,
				2043 => MessageSubCategory.TrimAnalysis,
				2045 => MessageSubCategory.TrimAnalysis,
				2046 => MessageSubCategory.TrimAnalysis,
				2050 => MessageSubCategory.TrimAnalysis,
				var x when x >= 2055 && x <= 2099 => MessageSubCategory.TrimAnalysis,
				2103 => MessageSubCategory.TrimAnalysis,
				2106 => MessageSubCategory.TrimAnalysis,
				2107 => MessageSubCategory.TrimAnalysis,
				var x when x >= 2109 && x <= 2116 => MessageSubCategory.TrimAnalysis,
				_ => MessageSubCategory.None,
			};
	}
}
